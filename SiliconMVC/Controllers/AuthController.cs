using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;
using System.Reflection;

namespace SiliconMVC.Controllers;

public class AuthController(UserService userService) : Controller
{

    //private readonly UserManager<UserEntity> _userManager;

    //public AuthController(UserManager<UserEntity> userManager)
    //{
    //    _userManager = userManager;
    //}

    private readonly UserService _userService = userService;

    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public async Task <IActionResult> SignIn(SignInViewModel viewModel)
    {

        if (ModelState.IsValid)
        {
            var result = await _userService.SignInUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCodes.Ok)
            {
                return RedirectToAction("Details", "Account");
            }
        }

        viewModel.ErrorMessage = "Invalid username or password.";
        return View(viewModel);

    }

    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        ViewData["Title"] = "Sign Up";
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCodes.Created)
            {
                return RedirectToAction("SignIn", "Auth");
            }
        }

        //if (ModelState.IsValid)
        //{
        //    _userManager.CreateAsync()
        //}



        return View(viewModel);
    }

    public new IActionResult SignOut()
    {
        return RedirectToAction("Index", "Home");
    }
}
