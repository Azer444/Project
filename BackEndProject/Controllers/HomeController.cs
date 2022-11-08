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

        private async Task<ShopProduct> GetProductById(int? id)
        {
            return await _context.ShopProducts.FindAsync(id);
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
