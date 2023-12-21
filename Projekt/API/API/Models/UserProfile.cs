public class UserProfile
{
    public UserProfile(){}
    public UserProfile(UserProfileDto dto)
    {
        Id = dto.Id;
        UserName = dto.UserName;
        Email = dto.Email;
        Bio = dto.Bio;
    }
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
}