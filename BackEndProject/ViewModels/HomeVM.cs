using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Info> Informations { get; set; }
        public OurProduct OurProduct { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Shoes> Shoes { get; set; }
        public TopSeller TopSellers { get; set; }
        public TopImage TopImages { get; set; }
        public IEnumerable<TopProduct> TopProducts { get; set; }
        public OurBlog OurBlogs { get; set; }
        public IEnumerable<TopBlog> TopBlogs { get; set; }
        public IEnumerable<BrandLogo> BrandLogos { get; set; }


    }
}
