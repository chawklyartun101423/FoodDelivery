using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class FoodViewModel
    {
		public int FoodId { get; set; }
		public string? FoodName { get; set; }
		public decimal? FoodPrice { get; set; }
		public int FoodCategoryId { get; set; }
		public int CategoryId { get; set; }
		public string? CategoryName { get; set; }

		[Required]
		public Food? Food { get; set; }

        [Required]
        public IEnumerable<FoodCategory>? FoodCategories { get; set; }
    }
}
