public interface IUserProfileService
{
    UserProfile GetUserProfile(int userId);
    UserProfile CreateUserProfile(UserProfile userProfile);
    UserProfile UpdateUserProfile(UserProfile userProfile);
    void DeleteUserProfile(int userId);
    // Add other methods as needed
}
