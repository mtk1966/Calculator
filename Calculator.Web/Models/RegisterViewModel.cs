using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bu alan gerekli")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
