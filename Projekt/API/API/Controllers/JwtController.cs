using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class JwtController
{
    private readonly IJwtService _jwtService;

    public JwtController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IResult> Register(
        [FromBody] RegisterRequestDTO user)
    {
        Console.WriteLine(user.ToString());
        return _jwtService.Register(user);
    }

    [HttpPost("login")]
    public async Task<IResult> Login(
        [FromBody] LoginRequestDTO requst)
    {
        Console.WriteLine(requst.ToString());
        return _jwtService.Login(requst);
    }
}