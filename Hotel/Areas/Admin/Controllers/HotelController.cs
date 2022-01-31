using Fiorella.Areas.Admin.Controllers.Constants;
using Fiorella.Areas.Admin.Utils;
using Hotel.Areas.Admin.ViewModels;
using Hotel.DAL;
using Hotel.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        private readonly HotelDbContext _context;
        public HotelController(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var hotels = await _context.HotelInfos.ToListAsync();
            return View(hotels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var hotels = await _context.HotelInfos.FindAsync(id);
            if (hotels == null)
            {
                return NotFound();
            }
            return View(hotels);
        }

        public async Task<IActionResult> Create()
        {
            var category = await _context.HotelCategories.Where(h=>!h.IsDeleted).ToListAsync();
            HotelCreateViewModel hotelCreateViewModel = new HotelCreateViewModel()
            {
                HotelCategories = category,
            };
            return View(hotelCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelCreateViewModel model)
        {
            var hotelCategory = await _context.HotelCategories.Where(c => !c.IsDeleted).ToListAsync();
            model.HotelCategories = hotelCategory;

            if (!ModelState.IsValid) return View(model);

            var category = await _context.HotelCategories.FindAsync(model.HotelCategoryId);

            if (category == null) return NotFound();

            var hotelImages = new List<HotelImage>();
            foreach (var image in model.Files)
            {
                if (image==null)
                {
                    return View();
                }
                if (!image.IsContains())
                {
                      ModelState.AddModelError("File", "File is not supported");
                      return View();
                }
                if (image.IsRightSize(1024))
                {
                     ModelState.AddModelError(nameof(model.Files), "Size can not be greater than 1mb.");
                }
                var hotelImage = FileUtils.FileCreate(FileConstants.ImagePath, image);
                hotelImages.Add(new HotelImage { ImageUrl = hotelImage });
            }

            var hotel = new HotelInfo()
            {
                Name = model.Name,
                Description = model.Description,
                HotelImages = hotelImages,
                CategoryId = model.HotelCategoryId,

            };

            await _context.HotelInfos.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Update(int id)
        {
            var hotel = await _context.HotelInfos.FindAsync(id);
            if (hotel == null) return NotFound();

            var hotelCategory = await _context.HotelCategories.Where(c => !c.IsDeleted).ToListAsync();

            var update = new HotelCreateViewModel()
            {
                Name = hotel.Name,
                Description = hotel.Description,
                HotelCategoryId = hotel.CategoryId,
            };
            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(HotelCreateViewModel model, int id)
        {

            var hotelCategory = await _context.HotelCategories.Where(c => !c.IsDeleted).ToListAsync();
            model.HotelCategories = hotelCategory;

            if (!ModelState.IsValid) return View(model);

            var hotel = await _context.HotelInfos.FirstOrDefaultAsync(h => h.Id == id);
            var oldImages = hotel.HotelImages.ToList();

            var hotelImages = new List<HotelImage>();
            foreach (var image in model.Files)
            {
                if (image == null)
                {
                    return View();
                }
                if (!image.IsContains())
                {
                    ModelState.AddModelError("File", "File is not supported");
                    return View();
                }
                if (image.IsRightSize(1024))
                {
                    ModelState.AddModelError(nameof(model.Files), "Size can not be greater than 1mb.");
                }
                var hotelImage = FileUtils.FileCreate(FileConstants.ImagePath, image);
                hotelImages.Add(new HotelImage { ImageUrl = hotelImage });


                
            }

            hotel.Name = model.Name;
            hotel.Description = model.Description;
            hotel.CategoryId = model.HotelCategoryId;
            hotel.HotelImages = hotelImages;

            _context.HotelInfos.Update(hotel);
            await _context.SaveChangesAsync();

            string path = Path.Combine(FileConstants.ImagePath, hotel.Image);
            FileUtils.FileDelete(path);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            HotelInfo hotel = await _context.HotelInfos.FirstOrDefaultAsync(h=>h.Id==id && !h.IsDeleted);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            HotelInfo hotel = await _context.HotelInfos.FirstOrDefaultAsync(h => h.Id == id && !h.IsDeleted);

            if (hotel == null)
            {
                return NotFound();
            }

            hotel.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
