using FrontToBack.DAL;
using FrontToBack.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public HomeController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public IActionResult Index()
		{
			HomeVM vm = new();
			vm.Sliders=_appDbContext.Sliders.ToList();
			vm.SliderContent=_appDbContext.SliderContents.FirstOrDefault();
			vm.Categories=_appDbContext.Categories.ToList();
			vm.Products=_appDbContext.Products.Include(p=>p.ProductImages).ToList();
			return View(vm);
		}

		public IActionResult Test()
		{
			return View();
		}
	}
}
