using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MTBusinessLogic.Model.DTO
{
    public class AddAlbumDTO
    {
        [Required(ErrorMessage = "input field can not be empty"), MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only letters are required")]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "input field can not be empty")]
        public int year { get; set; }
    }
}
