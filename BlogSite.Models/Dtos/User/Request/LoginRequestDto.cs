namespace BlogSite.Models.Dtos.User.Request;

public sealed record LoginRequestDto
    (
        string Email,
        string Password
    );  