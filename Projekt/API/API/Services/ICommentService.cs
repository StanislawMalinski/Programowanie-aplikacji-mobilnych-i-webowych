public interface ICommentService
{
    Comment GetComment(int commentId);
    IEnumerable<Comment> GetCommentsForPost(int postId);
    Comment CreateComment(Comment comment);
    Comment UpdateComment(Comment comment);
    void DeleteComment(int commentId);
    // Add other methods as needed
}
