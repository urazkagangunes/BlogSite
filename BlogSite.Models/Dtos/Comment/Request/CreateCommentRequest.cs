namespace BlogSite.Models.Dtos.Comment.Request;

internal class CreateCommentRequest
    (
        string Text,
        long UserId,
        Guid PostId
    );
