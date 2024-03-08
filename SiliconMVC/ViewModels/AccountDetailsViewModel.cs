using Infrastructure.Entities;
using SiliconMVC.Model;
using SiliconMVC.Model.Views;

namespace SiliconMVC.ViewModels
{
    public class AccountDetailsViewModel
    {
        public string Title { get; set; } = "Account Details";
        public UserEntity User { get; set; } = null!;
        public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel();
        public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();


    }
}
