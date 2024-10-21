namespace BlogSite.Models.Dtos.Comment.Request;

public sealed record CreateCommentRequest
    (
        string Text,
        long UserId,
        Guid PostId
    );
