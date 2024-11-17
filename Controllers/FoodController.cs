using FoodDelivery.Service;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

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
			var result= _foodService.GetFood(id);
			return View(result);
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
