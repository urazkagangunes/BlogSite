using BlogSite.Models.Dtos.Post.Request;
using BlogSite.Models.Dtos.Post.Response;
using BlogSite.Models.Entities;

namespace BlogSite.Service.Abstracts;

public interface IPostService
{
    List<PostResponseDto> GetAll();
    PostResponseDto GetById(int id);
    Post Add(CreatePostRequest create);
}
