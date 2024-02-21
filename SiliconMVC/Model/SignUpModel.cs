using System.ComponentModel.DataAnnotations;

namespace SiliconMVC.Model
{
    public class SignUpModel
    {
        [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
        [Required(ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
        [Required(ErrorMessage = "Invalid last name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address")]
        public string EmailAddress { get; set; } = null!;

        [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be 8-15 characters long and contain at least one uppercase letter, one lowercase letter, one digit and one special character")]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password", Prompt = "Re-enter your password", Order = 4)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "I agree to the terms and conditions", Order = 5)]
        [Required(ErrorMessage = "You must agree to the terms and conditions")]
        public bool TermsAndConditions { get; set; } = false;
    }
}
