using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
    public class FoodViewModel
    {
        [Required]
        public Food? Food { get; set; }

      
        [Required]
        public IEnumerable<FoodCategory>? FoodCategories { get; set; }
    }
}
