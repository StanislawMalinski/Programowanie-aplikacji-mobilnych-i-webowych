
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

    public async Task<IResult> Connect(HttpContext ctx, JwtOptions jwtOptions)
    {
        // validates the content type of the request
        if (ctx.Request.ContentType != "application/x-www-form-urlencoded")
            return Results.BadRequest(new { Error = "Invalid Request" });

        var formCollection = await ctx.Request.ReadFormAsync();

        // pulls information from the form
        if (formCollection.TryGetValue("grant_type", out var grantType) == false)
            return Results.BadRequest(new { Error = "Invalid Request" });

        if (formCollection.TryGetValue("userid", out var userId) == false)
            return Results.BadRequest(new { Error = "Invalid Request" });

        if (formCollection.TryGetValue("password", out var password) == false)
            return Results.BadRequest(new { Error = "Invalid Request" });

        //creates the access token (jwt token)
        var tokenExpiration = TimeSpan.FromSeconds(jwtOptions.ExpirationSeconds);
        var userIdInt = int.Parse(userId);
        var permissions = _jwtRepository.getPermissions(userIdInt);
        if (_jwtRepository.isAuthorized(userIdInt, password) == false)
            return Results.Unauthorized();
        var accessToken = CreateAccessToken(
            jwtOptions,
            userId,
            permissions);
        
  
        return Results.Ok(new
        {
            access_token = accessToken,
            expiration = (int)tokenExpiration.TotalSeconds,
            type = "bearer"
        });
    }

    public string CreateAccessToken(JwtOptions jwtOptions, string username, string[] permissions)
    {
        var keyBytes = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);
        var symmetricKey = new SymmetricSecurityKey(keyBytes);

        var signingCredentials = new SigningCredentials(
            symmetricKey,
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim("sub", username),
            new Claim("name", username),
            new Claim("aud", jwtOptions.Audience)
        };

        var roleClaims = permissions.Select(x => new Claim("role", x));
        claims.AddRange(roleClaims);

        var token = new JwtSecurityToken(
            issuer: jwtOptions.Issuer,
            audience: jwtOptions.Audience,
            claims: claims,
            expires: DateTime.Now.Add(TimeSpan.FromSeconds(jwtOptions.ExpirationSeconds)),
            signingCredentials: signingCredentials);

        var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
        return rawToken;
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