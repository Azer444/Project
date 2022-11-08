using BackEndProject.Data;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            List<BasketVM> basketItems = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            List<BasketDetailVM> basketDetail = new List<BasketDetailVM>();
            foreach (var item in basketItems)
            {
                ShopProduct shopProduct = await _context.ShopProducts
                    .Where(m => m.Id == item.Id && m.IsDeleted == false)
                    .Include(m => m.ProductImages).FirstOrDefaultAsync();

                BasketDetailVM newBasket = new BasketDetailVM
                {
                    Name = shopProduct.Name,
                    Image = shopProduct.ProductImages.Where(m=>m.IsMain).FirstOrDefault().Image,
                    Price = shopProduct.Price,
                    Count = item.Count,
                    Total = shopProduct.Price *item.Count
                
                };

                basketDetail.Add(newBasket);

            }
            return View(basketDetail);
        }
    }
}
