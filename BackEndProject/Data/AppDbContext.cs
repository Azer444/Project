using BackEndProject.Models;
using BackEndProject.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ProductCategory> ShopProducts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TwinBlog> TwinBlogs { get; set; }
        public DbSet<BrandSlider> BrandSliders { get; set; }
        public DbSet<SellerSlider> SellerSliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSlider> ProductSliders { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ShopProductModel> ShopProductModels { get; set; }

    }
}
