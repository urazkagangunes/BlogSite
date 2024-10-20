namespace BlogSite.Models.Dtos.Category.Response;

public sealed record CategoryResponseDto
{
    public int Id { get; init; }
    public string Name { get; init; }
}
