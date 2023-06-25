using System.IdentityModel.Tokens.Jwt;
using System.Text;
using api.Models.AppSettings;
using Microsoft.IdentityModel.Tokens;

namespace api.Services.Auth;

public class TokenService : ITokenService {
    private readonly AppSettings _appSettings;

    public TokenService(AppSettings appSettings) {
        this._appSettings = appSettings;
    }

    public string CreateToken() {
        if (
            this._appSettings.JWT is null
                || string.IsNullOrEmpty(this._appSettings.JWT.Audience)
                || string.IsNullOrEmpty(this._appSettings.JWT.Issuer)
                || string.IsNullOrEmpty(this._appSettings.JWT.Key)
        ) {
            throw new Exception("Invalid JWT Configuration");
        }

        DateTime expiration = DateTime.UtcNow.AddMinutes(60);
        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._appSettings.JWT.Key)),
            SecurityAlgorithms.HmacSha256
        );

        JwtSecurityToken token = new(
            issuer: this._appSettings.JWT.Issuer,
            audience: this._appSettings.JWT.Audience,
            expires: expiration,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
