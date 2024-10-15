namespace BlogSite.Models.Dtos.Post.Response;

public sealed record PostResponseDto
    (
        Guid Id,
        string Title,
        string Content,
        DateTime CreatedDate
    );
