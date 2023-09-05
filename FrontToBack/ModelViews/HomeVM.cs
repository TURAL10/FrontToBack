using FrontToBack.Entities;

namespace FrontToBack.ModelViews
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

        public SliderContent SliderContent { get; set; }
    }
}
