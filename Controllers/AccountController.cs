using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nachweis0r.Models;

namespace Nachweis0r.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> CreateUserAsync(RegisterViewModel registerViewModel)
    {
        if (!ModelState.IsValid) return View();
        var user = new User
        {
            UserName = registerViewModel.UserName
        };
        var result = await _userManager.CreateAsync(user, registerViewModel.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("LoginUser");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("Register", error.Description);
        }

        return View();
    }

    public async Task<IActionResult> AccessDenied()
    {
        return View();
    }

    //POST
    public async Task<IActionResult> LoginUserAsync(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid) return View();

        var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,
            loginViewModel.Password,
            loginViewModel.RememberMe,
            false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        if (result.IsLockedOut)
        {
            ModelState.AddModelError("Login", "You are locked out.");
        }
        else
        {
            ModelState.AddModelError("Login", "Failed to login.");
        }

        return View();
    }

    public async Task<IActionResult> LogoutUserAsync()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("LoginUser");
    }

    public async Task<IActionResult> EditUserAsync()
    {
        return View();
    }
}