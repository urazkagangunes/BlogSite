using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Dtos.User.Request;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IAuthenticationService
{
    Task<ReturnModel<TokenResponsesDto>> LoginAsync(LoginRequestDto loginRequestDto);
    Task<ReturnModel<TokenResponsesDto>> RegisterAsync(RegisterRequestDto registerRequestDto);
}
