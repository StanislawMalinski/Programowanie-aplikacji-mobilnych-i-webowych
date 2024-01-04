

using API.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

public class JwtRepository : IJwtRepository
{
    private readonly AppDbContext _dbContext;

    public JwtRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string[] getPermissions(int userId)
    {
        return (from j in _dbContext.Jwt
                where j.UserId == userId
                select j.Permissions)
                .FirstOrDefault() ?? new string[] { };
    }

    public bool isAuthorized(int userId, string jwt)
    {
        var token = (from j in _dbContext.Jwt
                where j.UserId == userId
                select j.Token)
                .FirstOrDefault();
        return token == jwt;
    }

    public void registerNewUser(RegisterRequestDTO user)
    {

        _dbContext.Users.Add(new UserProfileDto
        {
            Email = user.Email,
            UserName = user.UserName,
            Bio = ""
        });
        _dbContext.SaveChanges();
        var newUser = getUserProfile(user.Email);
        _dbContext.Jwt.Add(new JwtDto
        {
            UserId = newUser.Id,
            Token = user.Password,
            Permissions = ["user"]
        });
        _dbContext.SaveChanges();
    }

    private UserProfile getUserProfile(string email)
    {
        var user = (from u in _dbContext.Users
            where u.Email == email
            select UserProfileRepository.mapDtoToUser(u))
            .FirstOrDefault();
        return user;
    }

    public JwtDto? getUser(string email)
    {
        var token = (from u in _dbContext.Users
            where u.Email == email
            join j in _dbContext.Jwt on u.Id equals j.UserId
            select j)
            .FirstOrDefault();
        return token;
    }

    public void AddJwt(JwtDto jwt)
    {
        _dbContext.Jwt.Add(jwt);
        _dbContext.SaveChanges();
    }
}

