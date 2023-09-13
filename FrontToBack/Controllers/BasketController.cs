using FrontToBack.DAL;
using FrontToBack.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontToBack.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BasketController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBasket(int?id)
        {
            if (id == null) return NotFound();
            var existProduct=_appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();

            List<Product> list;
            string basket = Request.Cookies["basket"]; 
            if (basket == null) 
            {
                list = new();
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<Product>>(basket);
            }
            
            list.Add(existProduct); 
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(list), 
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) });
            return Content("set olundu...");
        }
        public IActionResult ShowBasket()
        {
            string basket = Request.Cookies["basket"];
            var products=JsonConvert.DeserializeObject<List<Product>>(basket);

            return Content($"value:{products[0].Name} ");
        }
    }
}
