﻿using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

public class AuthController : Controller
{
    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public IActionResult SignIn(SignInViewModel viewModel)
    {

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        //var result = _authService.SignIn(viewModel.Form);
        //if (!result)
        viewModel.ErrorMessage = "Invalid username or password.";
        return View(viewModel);

        return RedirectToAction("Account", "Index");
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
    public IActionResult SignUp(SignUpViewModel viewModel)
    {
        if(!ModelState.IsValid)
        {
            return View(viewModel);
        }

        return RedirectToAction("SignIn", "Auth");
    }

    public new IActionResult SignOut()
    {
        return RedirectToAction("Index", "Home");
    }
}
