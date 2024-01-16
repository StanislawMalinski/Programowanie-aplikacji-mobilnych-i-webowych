using API.Models;
using API.Models.Mapper;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IUserProfileRepository _userProfileRepository;

    public CommentRepository(AppDbContext dbContext, IUserProfileRepository userProfileRepository)
    {
        _dbContext = dbContext;
        _userProfileRepository = userProfileRepository;
    }

    public Comment GetComment(int commentId)
    {
        return (from c in _dbContext.Comments
                join u in _dbContext.Users on c.UserId equals u.Id
                where c.Id == commentId
                select mapDtoToComment(c, new UserProfile(u), c.PostId))
                .FirstOrDefault() ?? new Comment();
    }

    public IEnumerable<Comment> GetCommentsForPost(int postId)
    {
        return (from c in _dbContext.Comments
                join u in _dbContext.Users on c.UserId equals u.Id
                where c.PostId == postId
                orderby c.CreatedAt descending
                select mapDtoToComment(c, new UserProfile(u), postId))
                .ToList();
    }

    public List<Comment> GetAllComments()
    {
        return (from c in _dbContext.Comments
                join u in _dbContext.Users on c.UserId equals u.Id
                orderby c.CreatedAt descending
                select mapDtoToComment(c, new UserProfile(u), c.PostId))
                .ToList();
    }

    public Comment CreateComment(Comment comment)
    {
        comment.Id = -1;
        CommentDto dto = mapCommentToDto(comment);
        _dbContext.Comments.Add(dto);
        _dbContext.SaveChanges();
        return comment;
    }

    public Comment UpdateComment(Comment comment)
    {
        CommentDto dto = mapCommentToDto(comment);
        _dbContext.Comments.Update(dto);
        _dbContext.SaveChanges();
        return comment;
    }

    public void DeleteComment(int commentId)
    {
        var comment = _dbContext.Comments.Find(commentId);
        if (comment != null)
        {
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }
    }

    public void allDeleteComment(){
        var comment = _dbContext.Comments;
        if (comment != null)
        {
            _dbContext.Comments.RemoveRange(comment);
            _dbContext.SaveChanges();
        }
    }

    private static Comment mapDtoToComment(CommentDto dto, UserProfile user, int postId)
    {
        return CommentMapper.mapDtoToComment(dto, user, postId);
    }

    private static CommentDto mapCommentToDto(Comment comment)
    {
        return CommentMapper.mapCommentToDto(comment);
    }
}
