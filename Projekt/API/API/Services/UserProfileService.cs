public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileService(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public UserProfile GetUserProfile(int userId)
    {
        return _userProfileRepository.GetUserProfile(userId);
    }

    public UserProfile CreateUserProfile(UserProfile userProfile)
    {
        return _userProfileRepository.CreateUserProfile(userProfile);
    }

    public UserProfile UpdateUserProfile(UserProfile userProfile)
    {
        return _userProfileRepository.UpdateUserProfile(userProfile);
    }

    public void DeleteUserProfile(int userId)
    {
        _userProfileRepository.DeleteUserProfile(userId);
    }

    // Add other methods as needed
}
