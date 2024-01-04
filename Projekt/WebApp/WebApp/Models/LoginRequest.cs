public class LoginRequest {
    public string Email { get; set; }
    public string Password { get; set; }

    public override string ToString() {
        return $"Email: {Email}, Password: {Password}";
    }
}