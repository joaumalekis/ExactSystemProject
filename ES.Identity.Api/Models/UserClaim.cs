namespace ES.Identity.Api.Models;

public abstract class UserClaim
{
    public string Value { get; set; } = null!;
    public string Type { get; set; } = null!;
}