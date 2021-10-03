using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model.DTO
{
    public class AddArtistDTO
    {
        [Required(ErrorMessage = "input field can not be empty"), MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only letters are required")]
        [DataType(DataType.Text)]
        [Display(Name = "Biography")]
        public string biography { get; set; }

        [Required(ErrorMessage = "input field can not be empty"), MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only letters are required")]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string title { get; set; }
    }
}
