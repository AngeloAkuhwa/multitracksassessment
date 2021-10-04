using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model.DTO
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "input field can not be empty"), MaxLength(30)]
        [Display(Name = "FirstName")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "input field can not be empty"), MaxLength(30)]
        [Display(Name = "LastName")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "input field can not be empty"), MaxLength(80)]
        [Display(Name = "Church or Organization")]
        public string church { get; set; }

        [Required(ErrorMessage = "input field can not be empty"), MaxLength(50)]
        [Display(Name = "Language")]
        public string language { get; set; }

        [Required(ErrorMessage = "input field can not be empty"), MaxLength(30)]
        [Display(Name = "Country")]
        public string country { get; set; }

        [Required(ErrorMessage = "input field can not be empty"), MaxLength(30)]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "input field can not be empty"), MaxLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "Zip")]
        public int zip { get; set; }

        [Required(ErrorMessage = "input field can not be empty")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("password")]
        [Display(Name = "Confirm Password")]
        public string confirmPassword { get; set; }
    }
}
