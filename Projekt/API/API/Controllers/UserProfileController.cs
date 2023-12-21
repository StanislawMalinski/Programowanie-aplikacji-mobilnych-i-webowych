using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

// [Authorize]
[ApiController]
[Route("forum/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly IPostService _postService;

    public UserProfileController(IUserProfileService userProfileService, IPostService postService)
    {
        _userProfileService = userProfileService;
        _postService = postService;
    }

    // [AllowAnonymous]
    [HttpGet("{id}")]
    public ActionResult<UserProfile> GetUserProfile(int id)
    {
        var userProfile = _userProfileService.GetUserProfile(id);
        if (userProfile == null)
        {
            return NotFound();
        }

        return userProfile;
    }

    // [AllowAnonymous]
    [HttpGet("{id}/Post/page={page}")]
    public ActionResult<IEnumerable<Post>> GetCommentsForPost(int id, int page)
    {
        var posts = _postService.GetPagedPostForUserProfile(id, page);
        if (posts == null)
        {
            return NotFound();
        }

        return Ok(posts);
    }

    [HttpPost]
    public ActionResult<UserProfile> CreateUser([FromBody] UserProfile userProfile)
    {
        var createdUserProfile = _userProfileService.CreateUserProfile(userProfile);
        return CreatedAtAction(nameof(GetUserProfile), new { id = createdUserProfile.Id }, createdUserProfile);
    }

    [HttpPut]
    public ActionResult<UserProfile> UpdateUser([FromBody] UserProfile userProfile)
    {
        var updatedUserProfile = _userProfileService.UpdateUserProfile(userProfile);
        return Ok(updatedUserProfile);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        _userProfileService.DeleteUserProfile(id);
        return NoContent();
    }

    // Add other actions as needed
}
