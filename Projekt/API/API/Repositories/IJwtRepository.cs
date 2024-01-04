
using Models;

public interface IJwtRepository
{
    bool isAuthorized(int userId, string jwt);
    string [] getPermissions(int userId);
    JwtDto getUser(string email);
    void registerNewUser(RegisterRequestDTO user);
    void AddJwt(JwtDto jwt);
}