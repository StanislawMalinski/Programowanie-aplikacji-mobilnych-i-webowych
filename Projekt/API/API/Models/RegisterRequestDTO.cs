public record RegisterRequestDTO {
    public string Email { get; init; }
    public string Password { get; init; }
    public string UserName { get; init; }
}