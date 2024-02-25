using SiliconMVC.Model;
using SiliconMVC.Model.Views;

namespace SiliconMVC.ViewModels
{
    public class AccountDetailsViewModel
    {
        public string Title { get; set; } = "Account Details";
        public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel() 
        { 
            ProfileImage = "/images/Profile-image.svg",
            FirstName = "Jesper",
            LastName = "Kallioniemi",
            EmailAddress = "Jesper@domain.se"
        
        };
        public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();


    }
}
