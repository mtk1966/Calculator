using System.ComponentModel.DataAnnotations;

namespace Calculator.Web.Models
{
    public class ProcessViewModel
    {
        [Required]
        public double Number1 { get; set; }
        [Required]
        public double Number2 { get; set; }
        public double? Number3 { get; set; }
    }
}
