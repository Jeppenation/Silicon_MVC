using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconMVC.Model;
using SiliconMVC.Model.Views;
using SiliconMVC.ViewModels;

namespace SiliconMVC.Controllers
{

    //[Authorize]
    public class AccountController(UserManager<UserEntity> userManager) : Controller
    {
        private readonly UserManager<UserEntity> _userManager = userManager;

        #region Details [HttpGet]
        [Route("/account")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var viewModel = new AccountDetailsViewModel();
            viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
            viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

            return View(viewModel);
        }
        #endregion

        #region Details [HttpPost]
        [Route("/account")]
        [HttpPost]
        public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.BasicInfo != null) { }
                if (viewModel.AddressInfo != null) { }
            }

            viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
            viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

            return View(viewModel);
        }
        #endregion






        private async Task<AccountDetailsBasicInfoModel> PopulateBasicInfoAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            return new AccountDetailsBasicInfoModel
            {
                userId = user!.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.Email!,
                Phone = user.PhoneNumber,
                Bio = user.Bio
            };
        }

        private async Task<AccountDetailsAddressInfoModel> PopulateAddressInfoAsync()
        {

            return new AccountDetailsAddressInfoModel();

        }
    }
}
