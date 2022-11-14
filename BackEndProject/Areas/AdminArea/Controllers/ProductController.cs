using BackEndProject.Data;
using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1,int take = 5)
        {
            List<Product> products = await _context.Products
                .Where(m=>!m.IsDeleted)
                .Include(m=>m.ProductImages)
                .Include(m=>m.Category)
                .Skip((page*take)-take)
                .Take(take)
                .ToListAsync();
            ViewBag.take = take;
            List<ProductListVM> mapDatas = GetMapDatas(products);
            int count = await GetPageCount(take);
            Pagination<ProductListVM> result = new Pagination<ProductListVM>(mapDatas, page, count);
            return View(result);
        }

        private async Task<int> GetPageCount(int take)
        {
            int productCount = await _context.Products.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }


        private List<ProductListVM> GetMapDatas(List<Product> products)
        {
            List<ProductListVM> productList = new List<ProductListVM>();

            foreach (var product in products)
            {
                ProductListVM newproduct = new ProductListVM
                {
                    Id = product.Id,
                    Desc = product.Desc,
                    MainImage = product.ProductImages.Where(m=>m.IsMain).FirstOrDefault()?.Image,
                    Price = product.Price,
                    Name = product.Title,
                    
                };

                productList.Add(newproduct);
            }

            return productList;
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
