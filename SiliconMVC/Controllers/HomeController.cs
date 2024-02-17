using Microsoft.AspNetCore.Mvc;

namespace SiliconMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /User/
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";

            return View();
            
        }

        
    }
}
