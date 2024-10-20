using BlogSite.Models.Dtos.User.Request;
using BlogSite.Models.Dtos.User.Response;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IUserService
{
    ReturnModel<List<UserResponseDto>> GetAll();
    ReturnModel<UserResponseDto> GetById(long id);
    ReturnModel<UserResponseDto> Add(CreateUserRequest createUserRequest);
    ReturnModel<UserResponseDto> Update(UpdateUserRequest updateUserRequest);
    ReturnModel<UserResponseDto> Remove(long id);
}
