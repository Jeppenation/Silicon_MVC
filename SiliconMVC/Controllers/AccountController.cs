using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers
{

    //[Authorize]
    public class AccountController : Controller
    {
        [Route("/account")]
        public IActionResult Details()
        {
            var viewModel = new AccountDetailsViewModel();
            //viewModel.BasicInfo = _accountService.GetBasicInfo();
            //viewModel.AddressInfo = _accountService.GetAddressInfo();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveBasicInfo(AccountDetailsViewModel viewModel)
        {
            if (TryValidateModel(viewModel.BasicInfo))
            {
                return RedirectToAction("Index", "Home");

            }
            return View("Details", viewModel);
        }

        [HttpPost]
        public IActionResult AddressInfo(AccountDetailsViewModel viewModel)
        {
            if (TryValidateModel(viewModel.AddressInfo))
            {
                return RedirectToAction("Index", "Home");

            }
            return View("Details", viewModel);
        }

    }
}
