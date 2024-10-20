namespace BlogSite.Models.Dtos.User.Request;

public sealed record UpdateUserRequest
    (
        long Id,
        string FirstName,
        string LastName,
        string UserName,
        string Email,
        string Password
    );
