public interface ICommentRepository
{
    Comment GetComment(int commentId);
    IEnumerable<Comment> GetCommentsForPost(int postId);
    List<Comment> GetAllComments();
    Comment CreateComment(Comment comment);
    Comment UpdateComment(Comment comment);
    void DeleteComment(int commentId);
    void allDeleteComment();
}
