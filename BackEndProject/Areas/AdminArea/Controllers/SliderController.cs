using BackEndProject.Data;
using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.ViewModels.SliderViewModels;
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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreate)
        {
            if (!ModelState.IsValid) return View();

            foreach (var photo in sliderCreate.Photos)
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

            foreach (var photo in sliderCreate.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", fileName);

                await BackEndProject.Helper.Helper.SaveFile(path, photo);

                Slider newSlider = new Slider
                {
                    Image = fileName,
                    Selling = sliderCreate.Sale,
                    Title = sliderCreate.Title,
                    Desc = sliderCreate.Desc,
                };

                await _context.Sliders.AddAsync(newSlider);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();

            Slider slider = await GetByIdAsync(id);

            if (slider == null) return NotFound();

            SliderUpdateVM model = new SliderUpdateVM
            {
                Id = slider.Id,
                Sale = slider.Selling,
                Desc = slider.Desc,
                Title = slider.Title,
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM sliderUpdate)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return View(sliderUpdate);

            var dbSlider = await GetByIdAsync((int)id);

            if (dbSlider == null) return NotFound();

            if (sliderUpdate.Photos != null)
            {

                foreach (var photo in sliderUpdate.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photos", "Please choose correct image type");
                        return View(sliderUpdate);
                    }


                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photos", "Please choose correct image size");
                        return View(sliderUpdate);
                    }

                }

                foreach (var item in sliderUpdate.Photos)
                {
                    string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", dbSlider.Image);
                    BackEndProject.Helper.Helper.DeleteFile(path);
                }

                foreach (var photo in sliderUpdate.Photos)
                {

                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", fileName);

                    await BackEndProject.Helper.Helper.SaveFile(path, photo);

                    dbSlider.Image = fileName;

                }



            }

            dbSlider.Selling = sliderUpdate.Sale;
            dbSlider.Title = sliderUpdate.Title;
            dbSlider.Desc = sliderUpdate.Desc;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await GetByIdAsync(id);

            if (slider == null) return NotFound();

            string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", slider.Image);

            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            BackEndProject.Helper.Helper.DeleteFile(path);

            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private async Task<Slider> GetByIdAsync(int? id)
        {
            return await _context.Sliders
                                  .Where(m => m.Id == id)
                                  .FirstOrDefaultAsync();
        }
    }

}
