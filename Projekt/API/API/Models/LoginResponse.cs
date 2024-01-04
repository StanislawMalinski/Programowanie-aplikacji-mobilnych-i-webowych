using Models;

public class LoginResponse {
    public UserProfile? user { get; set; }
    public JwtDto? Jwt{ get; set; }
    public string? Message { get; set; }
}