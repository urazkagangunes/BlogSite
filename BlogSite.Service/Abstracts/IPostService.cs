using BlogSite.Models.Dtos.Post.Request;
using BlogSite.Models.Dtos.Post.Response;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IPostService
{
    ReturnModel<List<PostResponseDto>> GetAll();
    ReturnModel<PostResponseDto> GetById(Guid id);
    ReturnModel<PostResponseDto> Add(CreatePostRequest create);
    ReturnModel<PostResponseDto> Update(UpdatePostRequest update);
    ReturnModel<PostResponseDto> Remove(Guid id);
}
