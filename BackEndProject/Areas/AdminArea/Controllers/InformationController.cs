using BackEndProject.Data;
using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.ViewModels.InfoViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class InformationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public InformationController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Info> information = await _context.Informations.ToListAsync();
            return View(information);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InfoCreateVM infoCreate)
        {
            if (!ModelState.IsValid) return View();

            foreach (var photo in infoCreate.Photos)
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

            foreach (var photo in infoCreate.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", fileName);

                await BackEndProject.Helper.Helper.SaveFile(path, photo);

                Info newInfo = new  Info
                {
                    Image = fileName,
                    Title = infoCreate.Title,
                    Desc = infoCreate.Desc,
                    Color = infoCreate.Color,

                };

                await _context.Informations.AddAsync(newInfo);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            Info information = await GetByIdAsync((int)id);

            if (information == null) return NotFound();

            string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", information.Image);

            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            BackEndProject.Helper.Helper.DeleteFile(path);

            _context.Informations.Remove(information);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();

            Info information = await GetByIdAsync(id);

            if (information == null) return NotFound();

            InfoUpdateVM model = new InfoUpdateVM
            {
                Id = information.Id,
                Desc = information.Desc,
                Title = information.Title,
                Color = information.Color
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, InfoUpdateVM infoUpdate)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return View(infoUpdate);

            var dbInfo = await GetByIdAsync((int)id);

            if (dbInfo == null) return NotFound();

            if (infoUpdate.Photos != null)
            {

                foreach (var photo in infoUpdate.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photos", "Please choose correct image type");
                        return View(infoUpdate);
                    }


                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photos", "Please choose correct image size");
                        return View(infoUpdate);
                    }

                }

                foreach (var item in infoUpdate.Photos)
                {
                    string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", dbInfo.Image);
                    BackEndProject.Helper.Helper.DeleteFile(path);
                }

                foreach (var photo in infoUpdate.Photos)
                {

                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = BackEndProject.Helper.Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", fileName);

                    await BackEndProject.Helper.Helper.SaveFile(path, photo);

                    dbInfo.Image = fileName;
                }
            }


            dbInfo.Title = infoUpdate.Title;
            dbInfo.Desc = infoUpdate.Desc;
            dbInfo.Color = infoUpdate.Color;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<Info> GetByIdAsync(int? id)
        {
            return await _context.Informations.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
