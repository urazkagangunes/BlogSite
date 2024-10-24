using BlogSite.Models.Dtos.User.Request;
using BlogSite.Models.Entities;

namespace BlogSite.Service.Abstracts;

public interface IUserService
{
    Task<User> RegisterAsync(RegisterRequestDto registerDto);
    Task<User> GetByEmailAsync(string email);
    Task<User> LoginAsync(LoginRequestDto loginRequestDto);
    Task<User> UpdateAsync(string id, UserUpdateRequestDto updateDto);
    Task<string> DeleteAsync(string id);
    Task<User> ChangePasswordAsync(string id, ChangePasswordRequestDto changePasswordRequestDto);
}
