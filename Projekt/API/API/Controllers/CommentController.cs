using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

// [Authorize]
[ApiController]
[Route("forum/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    //[AllowAnonymous]
    [HttpGet("{id}")]
    public ActionResult<Comment> GetComment(int id)
    {
        var comment = _commentService.GetComment(id);
        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [HttpPost]
    public ActionResult<Comment> CreateComment([FromBody] Comment comment)
    {
        var createdComment = _commentService.CreateComment(comment);
        return CreatedAtAction(nameof(GetComment), new { id = createdComment.Id }, createdComment);
    }

    [HttpPut]
    public ActionResult<Comment> UpdateComment([FromBody] Comment comment)
    {
        var updatedComment = _commentService.UpdateComment(comment);
        return Ok(updatedComment);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteComment(int id)
    {
        _commentService.DeleteComment(id);
        return NoContent();
    }

    // Add other actions as needed
}
