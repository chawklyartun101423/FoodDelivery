using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Service
{
    public class FoodService
    {
        private readonly AppDbContext _context;

        public FoodService(AppDbContext context)
        {
            _context = context;
        }


        public void AddedFoodToCart(FoodSale food, int qty)
        {
            var isExistFood = _context.Foods.Any(x => x.FoodId == food.FoodId);

            if (isExistFood == true)
            {
                var foodData = _context.Foods.FirstOrDefault(f => f.FoodId == food.FoodId);
                if (foodData != null)
                {
                    // Check if the food already exists in the FoodSale table
                    var existingSale = _context.FoodSales
                                               .FirstOrDefault(fs => fs.FoodId == food.FoodId);
                    if (existingSale != null)
                    {
                        // If the food already exists in the FoodSale table, update its quantity
                        // Increment the existing quantity by the new quantity
                        existingSale.Qty += qty; 
                    }
                    else
                    {
                        // If the food does not exist in the FoodSale table, insert a new record
                        // Add the new sale record to the FoodSale table
                        var newSale = new FoodSale
                        {
                            SaleId = food.SaleId,
                            FoodId = food.FoodId,
                            Qty = qty,
                            FoodPrice = food.FoodPrice,
                            FoodName = food.FoodName// Set the initial quantity
                        };
                        _context.FoodSales.Add(newSale);
                    }
                    

                    

                    // Save changes to the database
                    _context.SaveChanges();
                }

            }
        }

    
        public List<FoodSale> GetAddedFoodList()
        {
            //retrieving Food List from FoodSale Table
            var fsl=_context.FoodSales.ToList();
            //var fsl = _context.FoodSales
            //          .Select(fs => new FoodSale
            //          {
            //              FoodId = fs.FoodId,
            //              Qty = fs.Qty,
            //              FoodPrice = fs.FoodPrice, // Only select the necessary properties
            //              FoodName = fs.FoodName
            //          })
            //          .ToList();
            return fsl;
        }

        public int CreateFood(Food food)
        {
            // Create New Food into Database Context
            _context.Foods.Add(food);
            var result = _context.SaveChanges();
            return result;
        }
        public List<Food> GetFoodList()

        { //retrieving Food list from Database
            var fl = _context.Foods.ToList();
            //    var foods = _context.Foods
            //.Include(f => f.)  // Eagerly load the related FoodCategory
            //.ToList();
            return fl;
        }


        public List<FoodCategory> GetFoodCategoryList()
        {
            var fcl = _context.FoodCategories.ToList();
            return fcl;
        }

        public int UpdateFood(Food food)
        {
            var isExistFood = _context.Foods.Any(x => x.FoodId == food.FoodId);
            if (isExistFood == true)
            {
                var result = _context.Foods.Where(x => x.FoodId == food.FoodId)
                .ExecuteUpdate(x => x
                .SetProperty(a => a.FoodName, food.FoodName)
                .SetProperty(a => a.FoodPrice, food.FoodPrice)
                .SetProperty(a => a.FoodCategoryId, food.FoodCategoryId));
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Food? GetFood(int id)
        {
            var isExistFood = _context.Foods.Any(x => x.FoodId == id);
            if (isExistFood == true)
            {
                var food = _context.Foods.FirstOrDefault(x => x.FoodId == id);
                return food;
            }
            return null;
        }

        public int DeleteFood(int FoodId)
        {
            var isExistFood = _context.Foods.Any(x => x.FoodId == FoodId);
            if (isExistFood)
            {
                var successDelete = _context.Foods.Where(x => x.FoodId == FoodId).ExecuteDelete();
                return successDelete;
            }
            return 0;
        }

        public bool DeleteAddedFood(int id)
        {
            var isExistFood= _context.FoodSales.Any(x=>x.FoodId == id);
            if (isExistFood) 
            {
                var successDelete = _context.FoodSales.Where(x => x.FoodId == id).ExecuteDelete();
                return true;
            }
               return false;

        }

    }
}
