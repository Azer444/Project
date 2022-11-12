using BackEndProject.Data;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        public ProductDetailController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            IEnumerable<ProductCategory> shopProducts = await _context.ShopProducts.Where(m => m.Id == id).Include(m => m.ProductImages).ToListAsync();
            IEnumerable<ProductCategory> shopProductsById = await _context.ShopProducts.Include(m => m.ProductImages).ToListAsync(); 

            ProductDetailVM productDetailVM = new ProductDetailVM
            {
                ShopProducts =shopProducts,
                ShopProductsById = shopProductsById

            };
            return View(productDetailVM);
        }
    }
}
