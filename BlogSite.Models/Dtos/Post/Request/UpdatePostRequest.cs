namespace BlogSite.Models.Dtos.Post.Request;

public sealed record UpdatePostRequest
    (
        Guid Id,
        string Title,
        string Content
    );
