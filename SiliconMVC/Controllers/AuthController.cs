using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconMVC.ViewModels;
using System.Reflection;

namespace SiliconMVC.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{

    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;

    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");

        }
        
        var viewModel = new SignInViewModel
        {
            Title = "Sign In"
        };
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public async Task <IActionResult> SignIn(SignInViewModel viewModel)
    {

        if(ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.EmailAddress, viewModel.Password, viewModel.RememberMe, false);

            if(result.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            }
        }

        ModelState.AddModelError("EmailAddress", "Invalid email address or password.");
        ViewData["ErrorMessage"] = "Invalid email address or password.";

        return View(viewModel);
    }

    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");
        }

        var viewModel = new SignUpViewModel
        {
            Title = "Sign Up"
        };
        return View(viewModel);
    }

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        //if (ModelState.IsValid)
        //{
        //    var result = await _userService.CreateUserAsync(viewModel);
        //    if (result.StatusCode == Infrastructure.Models.StatusCodes.Created)
        //    {
        //        return RedirectToAction("SignIn", "Auth");
        //    }
        //}

        if (ModelState.IsValid)
        {
            
            var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.EmailAddress);
            if(exists)
            {
                ModelState.AddModelError("EmailAddress", "Email address already exists.");
                ViewData["ErrorMessage"] = "Email address already exists.";
                return View(viewModel);
            }

            var userEntity = new UserEntity
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.EmailAddress,
                UserName = viewModel.EmailAddress
            };

            var result = await _userManager.CreateAsync(userEntity, viewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Auth");
            }
            
        }



        return View(viewModel);
    }

    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
