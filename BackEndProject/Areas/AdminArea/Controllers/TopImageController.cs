using BackEndProject.Data;
using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.ViewModels.TopImageModels;
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
    public class TopImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TopImageController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TopImage> topImages = await _context.TopImages.ToListAsync();
            return View(topImages);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TopImageCreateVM topimageCreate)
        {
            if (!ModelState.IsValid) return View();

            foreach (var photo in topimageCreate.Photos)
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

            foreach (var photo in topimageCreate.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", fileName);

                await BackEndProject.Helper.Helper.SaveFile(path, photo);

                TopImage newTopImage = new TopImage
                {
                    Image = fileName,
                };

                await _context.TopImages.AddAsync(newTopImage);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            TopImage topImage = await GetByIdAsync((int)id);

            if (topImage == null) return NotFound();

            string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", topImage.Image);

            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            BackEndProject.Helper.Helper.DeleteFile(path);

            _context.TopImages.Remove(topImage);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, TopImageUpdateVM imageUpdate)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return View(imageUpdate);

            var dbImage = await GetByIdAsync((int)id);

            if (dbImage == null) return NotFound();

            if (imageUpdate.Photos != null)
            {

                foreach (var photo in imageUpdate.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photos", "Please choose correct image type");
                        return View(imageUpdate);
                    }


                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photos", "Please choose correct image size");
                        return View(imageUpdate);
                    }

                }

                foreach (var item in imageUpdate.Photos)
                {
                    string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", dbImage.Image);
                    BackEndProject.Helper.Helper.DeleteFile(path);
                }

                foreach (var photo in imageUpdate.Photos)
                {

                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/banner", fileName);

                    await BackEndProject.Helper.Helper.SaveFile(path, photo);

                    dbImage.Image = fileName;
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }





        private async Task<TopImage> GetByIdAsync(int? id)
        {
            return await _context.TopImages.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
