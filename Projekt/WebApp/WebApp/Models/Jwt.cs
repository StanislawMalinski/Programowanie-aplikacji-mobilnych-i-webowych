namespace Models;
public record Jwt
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Token { get; set; }
    public required string[] Permissions { get; set; }
}