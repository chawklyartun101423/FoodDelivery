using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
	[Table("tbl_food")]
	public class Food
	{
		[Key]
		[Column("foodId")]
		public int FoodId { get; set; }

		[Column("foodName")]
		public string? FoodName { get; set; }

		[Column("foodPrice")]
		public decimal? FoodPrice {  get; set; }

		[Column("foodCategoryId")]
		public int FoodCategoryId {  get; set; }

    }
}
