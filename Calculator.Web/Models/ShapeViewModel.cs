using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Web.Models
{
    public enum ShapeType
    {
        Kare,
        Dikdörtgen,
        Üçgen
    }

    public class ShapeViewModel
    {
        public ShapeType SelectedShape { get; set; }

        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double Height { get; set; }

        public double? Area { get; set; }
        public double? Perimeter { get; set; }

        public List<ShapeType> Shapes { get; set; }

        public ShapeViewModel()
        {
            Shapes = new List<ShapeType>
            {
                ShapeType.Kare,
                ShapeType.Dikdörtgen,
                ShapeType.Üçgen
            };
        }
    }
}
