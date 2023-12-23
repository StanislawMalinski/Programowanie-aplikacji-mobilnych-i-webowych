    public interface IClientPost
    {
        Task<List<Post>> GetPosts(int page);
        Task<int> GetMaxPage();
        Task<Post> PostPost(Post post);
        Task<List<Post>> GetPostsForUserProfiles(int userId, int page);
        Task<Post> GetPost(string id);
        Task<Post> PutPost(Post post);
        Task<Boolean> DeletePost(string id);
    }