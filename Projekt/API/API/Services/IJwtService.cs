using Models;

public interface IJwtService
{
    Task<IResult> Connect(
        HttpContext ctx,
        JwtOptions jwtOptions);

    string CreateAccessToken(
        JwtOptions jwtOptions,
        string username,
        string[] permissions);


    IResult Register(RegisterRequestDTO user);

    IResult Login(LoginRequestDTO requst);
    IResult GetPermissions(LoginRequestDTO requst);
}