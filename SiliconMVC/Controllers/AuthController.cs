using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers;

public class AuthController : Controller
{
    [Route("/signin")]
    public IActionResult SignIn()
    {
        ViewData["Title"] = "Sign In";
        return View();
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
