namespace Application.Authorization.ViewModels;

public class TokenViewModel
{
    public string? AccessToken { get; set; }
    public DateTime? AccessTokenExpiration { get; set;}
    public string? RefreshToken { get; set; }
}