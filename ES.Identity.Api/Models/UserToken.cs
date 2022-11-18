namespace ES.Identity.Api.Models;

public abstract class UserToken
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IEnumerable<UserClaim> Claims { get; set; } = null!;
}