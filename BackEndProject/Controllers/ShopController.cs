using BackEndProject.Data;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            //HttpContext.Session.SetString("name", "Azer");
            //Response.Cookies.Append("surname", "Humbetov", new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
            List<ProductCategory> shopProducts = await _context.ShopProducts.Where(m=>!m.IsDeleted).Include(m => m.ProductImages).Where(m=>m.MainImage == true).ToListAsync();
            //IEnumerable<Model> models = await _context.Models.ToListAsync();

            //ShopVM shopVM = new ShopVM
            //{
                    
            //};

            return View(shopProducts);

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

            return RedirectToAction(nameof(Index));

        }

        private void UpdateBasket(List<BasketVM> basket, int id)
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

        private async Task<ProductCategory> GetProductById(int? id)
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
