using BackEndProject.Data;
using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.ViewModels.ShoeViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ShoeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ShoeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Shoes> shoes = await _context.Shoes.ToListAsync();
            return View(shoes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShoeCreateVM shoeCreate)
        {
            if (!ModelState.IsValid) return View();

            foreach (var photo in shoeCreate.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos", "Please choose correct image type");
                    return View();
                }


                if (!photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photos", "Please choose correct image size");
                    return View();
                }
            }

            foreach (var photo in shoeCreate.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", fileName);

                await BackEndProject.Helper.Helper.SaveFile(path, photo);

                Shoes newShoe = new Shoes
                {
                    Image = fileName,
                    SubTitle = shoeCreate.SubTitle,
                    Title = shoeCreate.Title
                };

                await _context.Shoes.AddAsync(newShoe);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();

            Shoes shoes = await GetByIdAsync(id);

            if (shoes == null) return NotFound();

            ShoeUpdateVM model = new ShoeUpdateVM
            {
                Id = shoes.Id,
                SubTitle = shoes.SubTitle,
                Title = shoes.Title
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ShoeUpdateVM shoeUpdate)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return View(shoeUpdate);

            var dbShoe = await GetByIdAsync((int)id);

            if (dbShoe == null) return NotFound();

            if (shoeUpdate.Photos != null)
            {

                foreach (var photo in shoeUpdate.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photos", "Please choose correct image type");
                        return View(shoeUpdate);
                    }


                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photos", "Please choose correct image size");
                        return View(shoeUpdate);
                    }

                }

                foreach (var item in shoeUpdate.Photos)
                {
                    string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", dbShoe.Image);
                    BackEndProject.Helper.Helper.DeleteFile(path);
                }

                foreach (var photo in shoeUpdate.Photos)
                {

                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", fileName);

                    await BackEndProject.Helper.Helper.SaveFile(path, photo);

                    dbShoe.Image = fileName;
                }
            }


            dbShoe.SubTitle = shoeUpdate.SubTitle;
            dbShoe.Title = shoeUpdate.Title;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Shoes shoes = await GetByIdAsync((int)id);

            if (shoes == null) return NotFound();

            string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", shoes.Image);

            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            BackEndProject.Helper.Helper.DeleteFile(path);

            _context.Shoes.Remove(shoes);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<Shoes> GetByIdAsync(int? id)
        {
            return await _context.Shoes.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

    }
}
