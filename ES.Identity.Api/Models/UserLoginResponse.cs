namespace ES.Identity.Api.Models;

public class UserLoginResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public double ExpiresIn { get; set; } 
    public UserToken UserToken { get; set; } = null!;
}