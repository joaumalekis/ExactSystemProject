using System.ComponentModel.DataAnnotations;

namespace ES.Identity.Api.Models;

public class NewUser
{
    [Required(ErrorMessage = "The field {0} is required")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "The field {0} is required")]
    public string SocialNumber { get; set; } = null!;

    [Required(ErrorMessage = "The field {0} is required")]
    [EmailAddress(ErrorMessage = "Invalid format of field {0}")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(100, ErrorMessage = "The field {0} should be between {2} and {1} chars", MinimumLength = 6)]
    public string Password { get; set; } = null!;

    [Compare("Password", ErrorMessage = "The password must match.")]
    public string ConfirmPassword { get; set; } = null!;
}