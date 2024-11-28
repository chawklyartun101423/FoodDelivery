using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{

    [Table("tbl_foodsale")]
    public class FoodSale
    {
        [Key]
        [Column("saleId")]
        public string SaleId { get; set; }

        [Column("foodId")]
        public int FoodId { get; set; }
        [Column("foodName")]
        public string? FoodName { get; set; }

        [Column("foodPrice")]
        public decimal? FoodPrice { get; set; }

        [Column("qty")]
        public int Qty { get; set; }

    }
}
