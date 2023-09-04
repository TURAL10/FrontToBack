using Microsoft.EntityFrameworkCore;

namespace FrontToBack.DAL
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}
	}
}
