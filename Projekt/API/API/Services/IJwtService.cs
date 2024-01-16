using Models;

public interface IJwtService
{
    IResult Register(RegisterRequestDTO user);

    IResult Login(LoginRequestDTO requst);
    IResult GetPermissions(LoginRequestDTO requst);
}