using BackEndProject.Data;
using BackEndProject.Models;
using BackEndProject.Services;
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
        private readonly LayoutService _layoutService;
        public BasketController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();
            IEnumerable<Category> categories = await _layoutService.GetDatasFromCategory();
            IEnumerable<Social> socials = await _context.Socials.ToListAsync();
            List<BasketVM> basketItems = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            List<BasketDetailVM> basketDetail = new List<BasketDetailVM>();
            foreach (var item in basketItems)
            {
                Product shopProduct = await _context.Products
                    .Where(m => m.Id == item.Id && m.IsDeleted == false)
                    .Include(m => m.ProductImages).FirstOrDefaultAsync();

                BasketDetailVM newBasket = new BasketDetailVM
                {
                    Name = shopProduct.Title,
                    Image = shopProduct.ProductImages.Where(m=>m.IsMain).FirstOrDefault().Image,
                    Price = shopProduct.Price,
                    Count = item.Count,
                    Total = shopProduct.Price *item.Count,

                };

                basketDetail.Add(newBasket);

            }
            return View(basketDetail);
        }
    }
}
