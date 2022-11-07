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
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("name", "Azer");
            Response.Cookies.Append("surname", "Humbetov",new CookieOptions {MaxAge=TimeSpan.FromDays(1)});
            Dictionary<string, string> settingDatas = await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
            IEnumerable<Language> languages = await _context.Languages.ToListAsync();
            IEnumerable<Currency> currencies = await _context.Currencies.ToListAsync();
            IEnumerable<Service> services = await _context.Services.ToListAsync();
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            IEnumerable<TwinBlog> twinBlogs = await _context.TwinBlogs.ToListAsync();
            IEnumerable<ShopProduct> shopProducts = await _context.ShopProducts.Include(m => m.ProductImages).Take(5).ToListAsync();


            HomeVM homeVM = new HomeVM
            {
                Currencies = currencies,
                Languages = languages,
                SettingDatas = settingDatas,
                Services = services,
                Sliders = sliders,
                TwinBlogs = twinBlogs,
                ShopProducts = shopProducts
            };




            return View(homeVM);
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id is null) return NotFound();

            var dbProduct = await _context.ShopProducts.FindAsync(id);

            if (dbProduct == null) return BadRequest();


            List<BasketVM> basket;

            if (Request.Cookies["basket"]!=null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }
            basket.Add(new BasketVM
            {
                Id = dbProduct.Id,
                Count = 1
            });

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));


            return RedirectToAction("Index");
        }
        
    }
}
