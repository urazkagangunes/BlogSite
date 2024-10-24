namespace BlogSite.Models.Dtos.User.Request;

public sealed record UserUpdateRequestDto
    (
        string FirstName,
        string LastName,
        string City,
        string UserName
    );
