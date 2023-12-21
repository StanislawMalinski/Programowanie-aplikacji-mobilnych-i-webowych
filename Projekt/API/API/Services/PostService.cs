public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private int _pageSize = 10;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public Post GetPost(int postId)
    {
        return _postRepository.GetPost(postId);
    }

    public IEnumerable<Post> GetPagedPostForUserProfile(int id, int page)
    {
        return _postRepository.GetPagedPostsForUserProfile(id, page, _pageSize);
    }

    public IEnumerable<Post> GetPagedPosts(int page)
    {
        return _postRepository.GetPagedPosts(page, _pageSize);
    }

    public Post CreatePost(Post post)
    {
        return _postRepository.CreatePost(post);
    }

    public Post UpdatePost(Post post)
    {
        return _postRepository.UpdatePost(post);
    }

    public void DeletePost(int postId)
    {
        _postRepository.DeletePost(postId);
    }

    public int GetMaxPage(){
        return _postRepository.GetMaxPage(_pageSize);
    }

    // Add other methods as needed
}
