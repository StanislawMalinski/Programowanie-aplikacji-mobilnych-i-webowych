public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private int _pageSize = 10;
    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public Comment GetComment(int commentId)
    {
        return _commentRepository.GetComment(commentId);
    }

    public IEnumerable<Comment> GetCommentsForPost(int postId)
    {
        return _commentRepository.GetCommentsForPost(postId);
    }

    public Comment CreateComment(Comment comment)
    {
        return _commentRepository.CreateComment(comment);
    }

    public Comment UpdateComment(Comment comment)
    {
        return _commentRepository.UpdateComment(comment);
    }

    public void DeleteComment(int commentId)
    {
        _commentRepository.DeleteComment(commentId);
    }

    // Add other methods as needed
}
