﻿using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.User.Request;
using BlogSite.Models.Dtos.User.Response;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    ReturnModel<UserResponseDto> IUserService.Add(CreateUserRequest createUserRequest)
    {
        try
        {
            User user = _mapper.Map<User>(createUserRequest);

            _userRepository.Add(user);

            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto>
            {
                Data = userResponseDto,
                Message = "new user added.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ReturnModel<UserResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

    ReturnModel<List<UserResponseDto>> IUserService.GetAll()
    {
        try
        {
            List<User> users = _userRepository.GetAll().ToList();
            List<UserResponseDto> userResponseDto = _mapper.Map<List<UserResponseDto>>(users);

            return new ReturnModel<List<UserResponseDto>>
            {
                Data = userResponseDto,
                Message = "Whole users listed.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception e)
        {
            return new ReturnModel<List<UserResponseDto>>
            {
                Data = null,
                Message = e.Message,
                StatusCode = 500,
                Success = false
            };
        }
    }

    ReturnModel<UserResponseDto> IUserService.GetById(long id)
    {
        try
        {
            User? user = _userRepository.GetById(id);
            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto>
            {
                Data = userResponseDto,
                Message = "Id User Getted.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception e)
        {
            return new ReturnModel<UserResponseDto>
            {
                Data = null,
                Message = e.Message,
                StatusCode = 500,
                Success = false
            };
        }

    }

    ReturnModel<UserResponseDto> IUserService.Remove(long id)
    {
        try
        {
            User? user = _userRepository.GetById(id);
            User? deletedUser = _userRepository.Remove(user);

            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(deletedUser);

            return new ReturnModel<UserResponseDto>
            {
                Data = userResponseDto,
                Message = "User deleted.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception e)
        {
            return new ReturnModel<UserResponseDto>
            {
                Data = null,
                Message = e.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

    ReturnModel<UserResponseDto> IUserService.Update(UpdateUserRequest updateUserRequest)
    {
        try
        {
            User? user = _userRepository.GetById(updateUserRequest.Id);
            User updateUser = new User
            {
                FirstName = updateUserRequest.FirstName,
                LastName = updateUserRequest.LastName,
                Email = updateUserRequest.Email,
                UserName = updateUserRequest.UserName,
                Password = updateUserRequest.Password,
            };

            User? updatedUser = _userRepository.Update(updateUser);
            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(updatedUser);

            return new ReturnModel<UserResponseDto>
            {
                Data = userResponseDto,
                Message = "User updated.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception e)
        {
            return new ReturnModel<UserResponseDto>
            {
                Data = null,
                Message = e.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }
}
