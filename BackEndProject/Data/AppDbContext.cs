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
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Info> Informations { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OurProduct> OurProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<TopSeller> TopSellers { get; set; }
        public DbSet<TopImage> TopImages { get; set; }
        public DbSet<TopProduct> TopProducts { get; set; }
        public DbSet<OurBlog> OurBlogs { get; set; }
        public DbSet<TopBlog> TopBlogs { get; set; }
        public DbSet<BrandLogo> BrandLogos { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Model> Models { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
