using API.Models;
using API.Models.Mapper;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly AppDbContext _dbContext;

    public UserProfileRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public UserProfile GetUserProfile(int userId)
    {
        return (from u in _dbContext.Users
                where u.Id == userId
                select mapDtoToUser(u))
                .FirstOrDefault() ?? new UserProfile();
                
    }

    public UserProfile CreateUserProfile(UserProfile userProfile)
    {
        UserProfileDto dto = mapUserToDto(userProfile);
        _dbContext.Users.Add(dto);
        _dbContext.SaveChanges();
        return userProfile;
    }

    public UserProfile UpdateUserProfile(UserProfile userProfile)
    {
        UserProfileDto dto = mapUserToDto(userProfile);
        _dbContext.Users.Update(dto);
        _dbContext.SaveChanges();
        return userProfile;
    }

    public List<UserProfile> GetAllUserProfile(){
        return _dbContext.Users
            .ToList()
            .Select(u => mapDtoToUser(u))
            .ToList();
    }

    public void DeleteUserProfile(int userId)
    {
        var userProfile = _dbContext.Users.Find(userId);
        if (userProfile != null)
        {
            _dbContext.Users.Remove(userProfile);
            _dbContext.SaveChanges();
        }
    }

    public void allDeleteUserProfile(){
        var userProfile = _dbContext.Users;
        if (userProfile != null)
        {
            _dbContext.Users.RemoveRange(userProfile);
            _dbContext.SaveChanges();
        }
    }

    public static UserProfile mapDtoToUser(UserProfileDto dto){
        return UserProfileMapper.mapDtoToUser(dto);
    }

    public static UserProfileDto mapUserToDto(UserProfile user){
        return UserProfileMapper.mapUserToDto(user);
    }
}
