using BlogSite.Models.Dtos.User.Request;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace BlogSite.Service.Concretes;

public sealed class UserService(UserManager<User> _userManager) : IUserService
{
    public async Task<User> ChangePasswordAsync(string id, ChangePasswordRequestDto changePasswordRequestDto)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            throw new NotFoundException("Kullancıı bulunamadı.");
        }
        
        if(!changePasswordRequestDto.NewPassword.Equals(changePasswordRequestDto.NewPasswordAgain))
        {
            throw new BusinessException("Parolalar eşleşmiyor.");
        }

        var result = await _userManager.ChangePasswordAsync(user, changePasswordRequestDto.CurrentPassword, changePasswordRequestDto.NewPassword);

        if (result.Succeeded)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return user;
    }

    public async Task<string> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        var result = await _userManager.DeleteAsync(user);

        if(result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return "Kullanıcı silindi.";
    }

    public async Task<User> GetByEmailAsync(string email)
    { 
        var user = await _userManager.FindByEmailAsync(email);

        if(user is null)
        {
            throw new NotFoundException("User did not find.");
        }

        return user;
    }

    public async Task<User> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);

        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        bool checkPassword = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

        if (checkPassword == false)
        {
            throw new BusinessException("Parola hatalı.");
        }

        return user;
    }

    public async Task<User> RegisterAsync(RegisterRequestDto registerDto)
    {
        User user = new User
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            City = registerDto.City,
            UserName = registerDto.UserName,
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if(!result.Succeeded)
        {
            throw new (result.Errors.ToList().First().Description);
        }

        return user;
    }

    public async Task<User> UpdateAsync(string id, UserUpdateRequestDto updateDto)
    {
        var user = await _userManager.FindByEmailAsync(id);

        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        user.UserName = updateDto.UserName;
        user.FirstName = updateDto.FirstName;
        user.LastName = updateDto.LastName;
        user.City = updateDto.City;

        var result = await _userManager.UpdateAsync(user);

        if(!result.Succeeded)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return user;
    }

















    //private readonly IUserRepository _userRepository;
    //private readonly IMapper _mapper;

    //public UserService(IUserRepository userRepository, IMapper mapper)
    //{
    //    _mapper = mapper;
    //    _userRepository = userRepository;
    //}
    //ReturnModel<UserResponseDto> IUserService.Add(CreateUserRequest createUserRequest)
    //{
    //    try
    //    {
    //        User user = _mapper.Map<User>(createUserRequest);

    //        _userRepository.Add(user);

    //        UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);

    //        return new ReturnModel<UserResponseDto>
    //        {
    //            Data = userResponseDto,
    //            Message = "new user added.",
    //            StatusCode = 200,
    //            Success = true
    //        };
    //    }
    //    catch (Exception ex)
    //    {
    //        return new ReturnModel<UserResponseDto>
    //        {
    //            Data = null,
    //            Message = ex.Message,
    //            StatusCode = 500,
    //            Success = false
    //        };
    //    }

    //}

    //ReturnModel<List<UserResponseDto>> IUserService.GetAll()
    //{
    //    try
    //    {
    //        List<User> users = _userRepository.GetAll().ToList();
    //        List<UserResponseDto> userResponseDto = _mapper.Map<List<UserResponseDto>>(users);

    //        return new ReturnModel<List<UserResponseDto>>
    //        {
    //            Data = userResponseDto,
    //            Message = "Whole users listed.",
    //            StatusCode = 200,
    //            Success = true
    //        };
    //    }
    //    catch (Exception e)
    //    {
    //        return new ReturnModel<List<UserResponseDto>>
    //        {
    //            Data = null,
    //            Message = e.Message,
    //            StatusCode = 500,
    //            Success = false
    //        };
    //    }
    //}

    //ReturnModel<UserResponseDto> IUserService.GetById(long id)
    //{
    //    try
    //    {
    //        User? user = _userRepository.GetById(id);
    //        UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);

    //        return new ReturnModel<UserResponseDto>
    //        {
    //            Data = userResponseDto,
    //            Message = "Id User Getted.",
    //            StatusCode = 200,
    //            Success = true
    //        };
    //    }
    //    catch(Exception e)
    //    {
    //        return new ReturnModel<UserResponseDto>
    //        {
    //            Data = null,
    //            Message = e.Message,
    //            StatusCode = 500,
    //            Success = false
    //        };
    //    }

    //}

    //ReturnModel<UserResponseDto> IUserService.Remove(long id)
    //{
    //    try
    //    {
    //        User? user = _userRepository.GetById(id);
    //        User? deletedUser = _userRepository.Remove(user);

    //        UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(deletedUser);

    //        return new ReturnModel<UserResponseDto>
    //        {
    //            Data = userResponseDto,
    //            Message = "User deleted.",
    //            StatusCode = 200,
    //            Success = true
    //        };
    //    }
    //    catch (Exception e)
    //    {
    //        return new ReturnModel<UserResponseDto>
    //        {
    //            Data = null,
    //            Message = e.Message,
    //            StatusCode = 500,
    //            Success = false
    //        };
    //    }

    //}

    //ReturnModel<UserResponseDto> IUserService.Update(UpdateUserRequest updateUserRequest)
    //{
    //    try
    //    {
    //        User? user = _userRepository.GetById(updateUserRequest.Id);
    //        User updateUser = new User
    //        {
    //            FirstName = updateUserRequest.FirstName,
    //            LastName = updateUserRequest.LastName,
    //            Email = updateUserRequest.Email,
    //            UserName = updateUserRequest.UserName,
    //            Password = updateUserRequest.Password,
    //        };

    //        User? updatedUser = _userRepository.Update(updateUser);
    //        UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(updatedUser);

    //        return new ReturnModel<UserResponseDto>
    //        {
    //            Data = userResponseDto,
    //            Message = "User updated.",
    //            StatusCode = 200,
    //            Success = true
    //        };
    //    }
    //    catch(Exception e)
    //    {
    //        return new ReturnModel<UserResponseDto>
    //        {
    //            Data = null,
    //            Message = e.Message,
    //            StatusCode = 500,
    //            Success = false
    //        };
    //    }

    //}

}
