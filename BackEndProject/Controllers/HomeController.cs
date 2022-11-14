using BackEndProject.Data;
using BackEndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;
using BackEndProject.Services;

namespace BackEndProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layout;

        public HomeController(AppDbContext context, LayoutService layout)
        {
            _context = context;
            _layout = layout;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            IEnumerable<Info> informations = await _context.Informations.Take(3).ToListAsync();
            IEnumerable<Product> products = await _context.Products.Include(m => m.ProductImages).ToListAsync();
            IEnumerable<Shoes> shoes = await _context.Shoes.Take(2).ToListAsync();
            IEnumerable<TopBlog> topBlogs = await _context.TopBlogs.ToListAsync();
            IEnumerable<BrandLogo> brandLogos = await _context.BrandLogos.ToListAsync();
            IEnumerable<TopProduct> topProducts = await _context.TopProducts.ToListAsync();
            OurProduct ourProduct = await _context.OurProducts.FirstOrDefaultAsync();
            TopSeller topSellers = await _context.TopSellers.FirstOrDefaultAsync();
            TopImage topImages = await _context.TopImages.Take(1).FirstOrDefaultAsync();
            OurBlog ourBlog = await _context.OurBlogs.FirstOrDefaultAsync();
      

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Informations = informations,
                OurProduct = ourProduct,
                Products = products,
                Shoes = shoes,
                TopSellers = topSellers,
                TopImages = topImages,
                TopProducts = topProducts,
                OurBlogs = ourBlog,
                TopBlogs = topBlogs,
                BrandLogos = brandLogos
            };

            return View(homeVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id is null) return BadRequest();

            var dbProduct = await GetProductById(id);

            if (dbProduct == null) return NotFound();

            List<BasketVM> basket = GetBasket();

            UpdateBasket(basket, dbProduct.Id);


            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));


            return RedirectToAction(nameof(Index ));
        }



        private void UpdateBasket(List<BasketVM> basket,int id)
        {
            BasketVM existProduct = basket.FirstOrDefault(m => m.Id == id);

            if (existProduct == null)
            {
                basket.Add(new BasketVM
                {
                    Id = id,
                    Count = 1
                });
            }
            else
            {
                existProduct.Count++;
            }
        }

        private async Task<Product> GetProductById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        private List<BasketVM> GetBasket()
        {

            List<BasketVM> basket;

            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }

            return basket;

        }
        
    }
}
