using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<Food> Foods { get; set; }
		public DbSet<FoodCategory> FoodCategories { get; set; }

	}
}
