using Models;

public class LoginResponse {
    public UserProfile? user { get; init; }
    public Jwt? Jwt{ get; init; }
    public string? Message { get; set; }
}