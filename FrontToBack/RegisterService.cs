using FrontToBack.DAL;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack
{
	public static class RegisterService
	{
		public static void Register(this IServiceCollection services, IConfiguration config)
		{
			services.AddControllersWithViews();
			services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
			});
		}
	}
}
