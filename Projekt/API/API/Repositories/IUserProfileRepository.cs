public interface IUserProfileRepository
{
    UserProfile GetUserProfile(int userId);
    UserProfile CreateUserProfile(UserProfile userProfile);
    UserProfile UpdateUserProfile(UserProfile userProfile);
    List<UserProfile> GetAllUserProfile();
    void DeleteUserProfile(int userId);
    void allDeleteUserProfile();
    // Add other methods as needed
}
