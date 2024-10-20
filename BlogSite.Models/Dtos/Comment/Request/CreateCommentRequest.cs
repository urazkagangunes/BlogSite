namespace BlogSite.Models.Dtos.Comment.Request;

public class CreateCommentRequest
    (
        string Text,
        long UserId,
        Guid PostId
    );
