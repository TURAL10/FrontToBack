using FrontToBack.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.DAL
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<SliderContent> SliderContents { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<Bio> Bios { get; set; }

	}
}
