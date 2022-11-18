using ES.Identity.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ES.Identity.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(NewUser newUser)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        
        var user = new IdentityUser
        {
            UserName = newUser.Email,
            Email = newUser.Email,
            EmailConfirmed = true
        };
        
        var result = await _userManager.CreateAsync(user, newUser.Password);

        if (!result.Succeeded) return BadRequest();
        
        await _signInManager.SignInAsync(user, false);
        return Ok();

    }
    
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(UserLogin userLogin)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        
        var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }
}