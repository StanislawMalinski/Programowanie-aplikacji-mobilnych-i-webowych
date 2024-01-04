namespace Models;
public record JwtDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Token { get; set; }
    public string[] Permissions { get; set; }
}