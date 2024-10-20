using BlogSite.Models.Dtos.Comment.Response;
using BlogSite.Models.Dtos.Comment.Request;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICommentService
{
    ReturnModel<List<CommentResponseDto>> GetAll();
    ReturnModel<CommentResponseDto> GetById(Guid id);
    ReturnModel<CommentResponseDto> Add(CreateCommentRequest createCommentRequest);
    ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateCommentRequest);
    ReturnModel<CommentResponseDto> Remove(Guid id);
}
