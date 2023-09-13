using FrontToBack.DAL;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack
{
	public static class RegisterService
	{
		public static void Register(this IServiceCollection services, IConfiguration config)
		{
			services.AddControllersWithViews()
				.AddNewtonsoftJson(options =>
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
			services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
			});
			services.AddSession(option =>
			{
				option.IdleTimeout = TimeSpan.FromMinutes(1);
			});
		}
	}
}
