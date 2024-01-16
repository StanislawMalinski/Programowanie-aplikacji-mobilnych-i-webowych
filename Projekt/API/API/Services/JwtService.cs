
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Models;

public class JwtService : IJwtService
{

    private readonly IJwtRepository _jwtRepository;
    private readonly IUserProfileRepository _userProfileRepository;

    public JwtService(IJwtRepository jwtRepository, IUserProfileRepository userProfileRepository)
    {
        _jwtRepository = jwtRepository;
        _userProfileRepository = userProfileRepository;
    }

    public IResult Register(RegisterRequestDTO user){
        var response = new LoginResponse();
        var result = _jwtRepository.getUser(user.Email);
        if (result != null){
            response.Message = "User already exists.";
            return Results.Ok(response);
        }
        _jwtRepository.registerNewUser(user);
        var new_user = _userProfileRepository.getUser(user.Email);
        result = _jwtRepository.getUser(user.Email);
        response = new LoginResponse
        {
            user = new_user,
            Jwt = result
        };
        return Results.Ok(response);
    }

    public IResult Login(LoginRequestDTO requst){
        var response = new LoginResponse();
        var result = _jwtRepository.getUser(requst.Email);
        if (result == null){
            response.Message = "User does not exist.";
            return Results.Ok(response);
        }
        if (result.Token != requst.Password) {
            response.Message = "Incorrect password.";
            return Results.Ok(response);
        }
        var user = _userProfileRepository.getUser(requst.Email);
        response = new LoginResponse
        {
            user = user,
            Jwt = result
        };
        return Results.Ok(response);

    }

    public IResult GetPermissions(LoginRequestDTO requst)
    {
        var result = _jwtRepository.getUser(requst.Email);
        if (result == null)
            return Results.BadRequest("User does not exist.");
        if (result.Token != requst.Password)
            return Results.BadRequest("Incorrect password.");
        var permissions = _jwtRepository.getPermissions(result.UserId);
        return Results.Ok(permissions);
    }
}