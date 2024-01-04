public interface IUserProfileRepository
{
    UserProfile GetUserProfile(int userId);
    UserProfile CreateUserProfile(UserProfile userProfile);
    UserProfile UpdateUserProfile(UserProfile userProfile);
    List<UserProfile> GetAllUserProfile();
    void DeleteUserProfile(int userId);
    void allDeleteUserProfile();
    UserProfile getUser(string email);
}
