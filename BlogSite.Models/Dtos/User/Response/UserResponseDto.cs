namespace BlogSite.Models.Dtos.User.Response;

public sealed record UserResponseDto
{
    public long Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}
