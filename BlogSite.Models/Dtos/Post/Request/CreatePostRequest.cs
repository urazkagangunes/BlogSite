namespace BlogSite.Models.Dtos.Post.Request;

public sealed record CreatePostRequest
    (
        string Title, 
        string Content,
        int CategoryId
    );

