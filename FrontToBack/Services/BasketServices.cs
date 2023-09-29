using FrontToBack.ModelViews;
using Newtonsoft.Json;

namespace FrontToBack.Services
{
    public class BasketServices : IBasket
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public BasketServices(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetBasketCount()
        {
            string basket = _contextAccessor.HttpContext.Request.Cookies["basket"];
            if (basket != null)
            {
                var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                return products.Sum(p => p.BaketCount);
            }
            return 0;
        }
    }
}
