using FrontToBack.DAL;
using FrontToBack.Entities;
using FrontToBack.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var query =_appDbContext.Products.AsQueryable(); 
            var products = query
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Take(4)
                .ToList();
            ViewBag.ProductCount = query.Count();
            
            return View(products);
        }

        public IActionResult LoadMore(int skip)
        {
            var products=_appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Skip(skip)
                .Take(4)
                .ToList();

            return PartialView("_LoadMorePartial",products);
        }

        public IActionResult Search(string search)
        {
            var products = _appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p=>p.Name.ToLower().Contains(search.ToLower()))
                .OrderBy(p=>p.Id)
                .Take(10)
                .ToList();
            return PartialView("_SearchPartial", products);
        }
    }
}
