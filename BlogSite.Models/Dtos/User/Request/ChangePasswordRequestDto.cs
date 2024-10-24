namespace BlogSite.Models.Dtos.User.Request;

public sealed record ChangePasswordRequestDto
    (
        string CurrentPassword,
        string NewPassword,
        string NewPasswordAgain
    );