using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "input field can not be empty")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "User Name or Email")]
        public string email {  get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Password Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password {  get; set; }
    }
}
