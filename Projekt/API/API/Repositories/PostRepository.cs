using API.Models;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _dbContext;
    private readonly Random random;

    public PostRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        random = new Random();
    }

    public Post GetPost(int postId)
    {
        return (from p in _dbContext.Posts
                        join u in _dbContext.Users on p.UserId equals u.Id
                        join c in _dbContext.Comments on p.Id equals c.PostId into comments
                        where p.Id == postId
                        select mapDtoToPost(p, new UserProfile(u), comments.Select(c => new Comment(c)).ToList()))
                        .FirstOrDefault() ?? new Post();
    }

    public IEnumerable<Post> GetPagedPostsForUserProfile(int userId, int page, int pageSize)
    {
        return (from p in _dbContext.Posts
                        join u in _dbContext.Users on p.UserId equals u.Id
                        join c in _dbContext.Comments on p.Id equals c.PostId into comments
                        where p.UserId == userId
                        orderby p.CreatedAt descending
                        select mapDtoToPost(p, new UserProfile(u), comments.Select(c => new Comment(c)).ToList()))
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
    }

    public IEnumerable<Post> GetPagedPosts(int page, int pageSize)
    {
        return (from p in _dbContext.Posts
                        join u in _dbContext.Users on p.UserId equals u.Id
                        join c in _dbContext.Comments on p.Id equals c.PostId into comments
                        orderby p.CreatedAt descending
                        select mapDtoToPost(p, new UserProfile(u), comments.Select(c => new Comment(c)).ToList()))
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
    }

    public List<Post> GetAllPosts()
    {

        return (from p in _dbContext.Posts
                join u in _dbContext.Users on p.UserId equals u.Id
                join c in _dbContext.Comments on p.Id equals c.PostId into comments
                orderby p.CreatedAt descending
                select mapDtoToPost(p, 
                            new UserProfile(u), 
                            comments.Select(c => new Comment(c)).ToList()))
                .ToList();
    }

    public Post CreatePost(Post post)
    {
        bool success = false;
        while (!success)
        {
            try
            {
                post.Id = getNextId();
                PostDto dto = mapPostToDto(post);
                _dbContext.Posts.Add(dto);
                _dbContext.SaveChanges();
                success = true;
            }
            catch (DbUpdateException)
            {
                success = false;
            }
        }
        return post;
    }

    private int getNextId()
    {
        return random.Next(100, 9999999);
    }

    public Post UpdatePost(Post post)
    {
        PostDto dto = mapPostToDto(post);
        _dbContext.Posts.Update(dto);
        _dbContext.SaveChanges();
        return post;
    }

    public void DeletePost(int postId)
    {
        var post = _dbContext.Posts.Find(postId);
        if (post != null)
        {
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }
    }

    public void allDeletePost()
    {
        var post = _dbContext.Posts;
        if (post != null)
        {
            _dbContext.Posts.RemoveRange(post);
            _dbContext.SaveChanges();
        }
    }

    public int GetMaxPage(int pageSize)
    {
        var count = _dbContext.Posts.Count();
        return (int)Math.Ceiling((double)count / pageSize);
    }

    private static Post mapDtoToPost(PostDto dto, UserProfile user, List<Comment> comments)
    {
        Post post = PostMapper.mapDtoToPost(dto, user, comments);
        return post;
    }

    private static PostDto mapPostToDto(Post post)
    {
        return PostMapper.mapPostToDto(post);
    }

    public int GetMaxPageForUser(int id, int pageSize)
    {
        var count = _dbContext.Posts.Where(p => p.UserId == id).Count();
        return (int)Math.Ceiling((double)count / pageSize);
    }
    // Implement other methods as needed
}
