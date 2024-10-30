using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Dtos.User.Request;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
{
    public async Task<ReturnModel<TokenResponsesDto>> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var user = await _userService.LoginAsync(loginRequestDto);
        var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponsesDto>
        {
            Data = tokenResponse,
            Message = "Giriş Başarılı.",
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<TokenResponsesDto>> RegisterAsync(RegisterRequestDto registerRequestDto)
    {
        var user = await _userService.RegisterAsync(registerRequestDto);
        var registerResponse = await _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponsesDto>
        {
            Data = registerResponse,
            Message = "Kayıt Başarılı.",
            StatusCode = 200,
            Success = true
        };
    }
}
