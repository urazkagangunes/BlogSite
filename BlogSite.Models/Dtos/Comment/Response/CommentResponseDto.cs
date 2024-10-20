using BlogSite.Models.Entities;

namespace BlogSite.Models.Dtos.Comment.Response;

public sealed record CommentResponseDto
{
    public Guid Id { get; init; }
    public string Text { get; init; }
    public string User { get; init; }
    public string Post { get; init; }
}
