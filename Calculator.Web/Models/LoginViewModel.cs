using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bu alan gerekli")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; } 
    }
}
