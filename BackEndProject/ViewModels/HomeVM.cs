using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Currency> Currencies { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public Dictionary<string, string> SettingDatas { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<TwinBlog> TwinBlogs { get; set; }
        public IEnumerable<ProductCategory> ShopProducts { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<BrandSlider> BrandSliders { get; set; }
        public IEnumerable <SellerSlider> SellerSliders { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }


    }
}
