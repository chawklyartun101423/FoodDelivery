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

    }
}
