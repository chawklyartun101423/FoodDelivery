using FoodDelivery.Service;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodDelivery.Controllers
{
	public class FoodController : Controller
	{
		private readonly FoodService _foodService;

		public FoodController(FoodService foodService) 
		{
			_foodService=foodService;
		}
		public IActionResult FoodListing()
		{
			var foodList= _foodService.GetFoodList();
			return View(foodList);
		}
		public IActionResult AddFood()
		{
            var model = new FoodViewModel
            {
                Food = new Food(),  // Empty Food object for binding
                FoodCategories = _foodService.GetFoodCategoryList() // Load all categories
            };

            return View(model);
		}
		public IActionResult SaveFood(Food food)
		{ var result = _foodService.CreateFood(food);
			if (result > 0)
			{
				return RedirectToAction("FoodListing");
			}
			return View();
		}

		[HttpGet]
		public IActionResult EditFood(int id)
		{
			var foodViewModel= _foodService.GetFood(id);
			 var foodCategories = _foodService.GetFoodCategoryList();

			// Check if foodCategories is not empty and assign a default or selected category
			var selectedCategory = foodCategories.FirstOrDefault(); // or logic to pick a specific category
			if (selectedCategory == null)
			{
				// Handle case where no categories are available (optional)
				return NotFound("Food categories are not available.");
			}
			//var food = new Food()
			//{
			//	FoodPrice = foodViewModel.FoodPrice,
			//	FoodName = foodViewModel.FoodName,
			//	FoodCategoryId = selectedCategory.CategoryId
			//};
			FoodViewModel foodViewModelForView = new FoodViewModel()
			{
				// Set properties based on food data from foodViewModel (which is assumed to be a Food model)
				FoodId = foodViewModel.FoodId,  // Assuming Food has a FoodId property
				FoodName = foodViewModel.FoodName,
				FoodPrice = foodViewModel.FoodPrice,
				FoodCategoryId = selectedCategory.CategoryId, // This will be the selected category ID (or you can choose a specific one based on your logic)

				// Step 5: Pass food categories to the view using a SelectList (for dropdown)
			//	FoodCategories = new SelectList(foodCategories, "CategoryId", "CategoryName", selectedCategory.CategoryId)
			};
			return View(foodViewModelForView);
		}

		[HttpPost]
		public IActionResult Update(Food food)
		{
			var result = _foodService.UpdateFood(food);
			if (result > 0)
			{
				return RedirectToAction("FoodListing");
			}
			return View();
		}
		[HttpGet]
		public IActionResult DeleteFood(int id)
		{ var result= _foodService.GetFood(id);
			return View(result);
		}

		[HttpPost]
		public IActionResult RemoveFood(int foodId)
		{var result= _foodService.DeleteFood(foodId);
			if(result > 0)
			{
				return RedirectToAction("FoodListing");
			}
			return View();
		}

	}
}
