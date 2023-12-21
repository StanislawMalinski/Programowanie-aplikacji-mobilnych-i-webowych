public interface IPostRepository
{
    Post GetPost(int postId);
    IEnumerable<Post> GetPagedPostsForUserProfile(int userId, int page, int pageSize);
    IEnumerable<Post> GetPagedPosts(int page, int pageSize);
    List<Post> GetAllPosts();
    Post CreatePost(Post post);
    Post UpdatePost(Post post);
    void DeletePost(int postId);
    void allDeletePost();
    int GetMaxPage(int pageSize);

    // Add other methods as needed
}
