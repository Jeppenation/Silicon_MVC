using Microsoft.AspNetCore.Mvc;

namespace SiliconMVC.Controllers
{
    public class AuthController : Controller
    {
        [Route("/signin")]
        public IActionResult SignIn()
        {
            ViewData["Title"] = "Sign In";
            return View();
        }

        [Route("/signup")]
        public IActionResult SignUp()
        {
            ViewData["Title"] = "Sign Up";
            return View();
        }

        public new IActionResult SignOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
