using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

// [Authorize]
[ApiController]
[Route("forum/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly ICommentService _commentService;

    public PostController(IPostService postService, ICommentService commentService)
    {
        _postService = postService;
        _commentService = commentService;
    }

    // [AllowAnonymous]
    [HttpGet("{id}")]
    public ActionResult<Post> GetPost(int id)
    {
        var post = _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpGet("{id}/Comment")]
    public ActionResult<IEnumerable<Comment>> GetCommentsForPost(int id)
    {
        var comments = _commentService.GetCommentsForPost(id);
        if (comments == null)
        {
            return NotFound();
        }

        return Ok(comments);
    }

    [HttpGet("page={page}")]
    public ActionResult<IEnumerable<Post>> GetPagedPosts(int page)
    {
        var posts = _postService.GetPagedPosts(page);
        if (posts == null)
        {
            return NotFound();
        }

        return Ok(posts);
    }

    [HttpGet("maxpage")]
    public ActionResult<int> GetMaxPage()
    {
        var maxPage = _postService.GetMaxPage();
        if (maxPage == 0)
        {
            return NotFound();
        }

        return Ok(maxPage);
    }

    [HttpPost]
    public ActionResult<Post> CreatePost([FromBody] Post post)
    {
        var createdPost = _postService.CreatePost(post);
        return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, createdPost);
    }

    [HttpPut]
    public ActionResult<Post> UpdatePost([FromBody] Post post)
    {
        var updatedPost = _postService.UpdatePost(post);
        return Ok(updatedPost);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePost(int id)
    {
        _postService.DeletePost(id);
        return NoContent();
    }
}
