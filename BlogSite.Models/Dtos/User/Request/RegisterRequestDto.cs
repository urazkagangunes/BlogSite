namespace BlogSite.Models.Dtos.User.Request;

public sealed record RegisterRequestDto
    (
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string UserName,
        string City
    );

