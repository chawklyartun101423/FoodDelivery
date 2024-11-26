namespace FoodDelivery.Models
{
    public class FoodSaleDataModel
    {
        public int SaleId { get; set; }
        public string? FoodId { get; set; }
        public string? FoodName { get; set; }
        public decimal FoodPrice { get; set; }
        public string? FoodPhoto { get; set; }
        public int Qty { get; set; }

    }
}
