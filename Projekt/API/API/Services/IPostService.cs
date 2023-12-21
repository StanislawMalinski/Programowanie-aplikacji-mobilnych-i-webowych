using Microsoft.AspNetCore.Mvc.RazorPages;

public interface IPostService
{
    Post GetPost(int postId);
    IEnumerable<Post> GetPagedPostForUserProfile(int id, int page);
    IEnumerable<Post> GetPagedPosts(int page);
    Post CreatePost(Post post);
    Post UpdatePost(Post post);
    void DeletePost(int postId);
    int GetMaxPage();

    // Add other methods as needed
}
