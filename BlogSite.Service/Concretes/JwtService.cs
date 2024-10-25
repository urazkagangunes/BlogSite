using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Tokens.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogSite.Service.Concretes;

public sealed class JwtService : IJwtService
{
    private readonly TokenOption _tokenOption;

    public JwtService(IOptions<TokenOption> tokenOption)
    {
        _tokenOption = tokenOption.Value;
    }

    public TokenResponsesDto CreateJwtToken(User user)
    {
        var accessTokenExpirarion = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
        var secretKey = SecurityKeyHelper.GetSecurityKey(_tokenOption.SecurityKey);

        SigningCredentials sc = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                issuer: _tokenOption.Issuer,
                claims: GetClaims(user, _tokenOption.Audience),
                expires: accessTokenExpirarion,
                signingCredentials: sc
            );

        var handler = new JwtSecurityTokenHandler();
        string token = handler.WriteToken(jwtSecurityToken);

        return new TokenResponsesDto
        {
            AccessToken = token,
            AccessTokenExpiration = accessTokenExpirarion
        };
    }

    public List<Claim> GetClaims(User user, List<string> audiences)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id), 
            new Claim("email", user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("Uraz_kağan", "Güneş")
        };

        claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

        return claims;
    }
}
