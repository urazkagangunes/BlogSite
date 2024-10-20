namespace BlogSite.Models.Dtos.Comment.Request;

public sealed record UpdateCommentRequest
    (
        Guid Id,
        string Text
    );
