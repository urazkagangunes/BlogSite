namespace BlogSite.Models.Dtos.User.Request;

public sealed record CreateUserRequest
    (
        string FirstName,
        string LastName,
        string UserName,
        string Email,
        string Password
    );
