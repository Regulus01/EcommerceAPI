namespace Domain.Authentication.Configuration;

public class TokenModel
{
    public string? AccessToken { get; }
    public DateTime? AccessTokenExpiration { get; }
    public string? RefreshToken { get; }

    public TokenModel() { }
    public TokenModel(string? accessToken, DateTime? acessTokenExpiration, string? refreshToken)
    {
        AccessToken = accessToken;
        AccessTokenExpiration = acessTokenExpiration;
        RefreshToken = refreshToken;
    }
}