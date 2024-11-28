namespace FoodDelivery.Models
{
    public static class ChangeModel
    {
        public static FoodSale Change(this Food model)
        {
            if (model == null)
            {
                return new();
            }

            return new FoodSale
            {
                SaleId = Guid.NewGuid().ToString(),
                FoodId = model.FoodId,
                FoodName = model.FoodName,
                FoodPrice = (decimal)model.FoodPrice,
            };
        }
    }
}
