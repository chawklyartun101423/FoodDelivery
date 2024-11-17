using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
	[Table("tbl_foodCategory")]
	public class FoodCategory
	{
	[Key]
	[Column("foodCategoryId")]
		public int CategoryId { get; set; }

	[Column("categoryName")]
	public string? CategoryName { get; set; }
	}
}
