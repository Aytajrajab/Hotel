using Hotel.DAL;
using Hotel.Models;
using Hotel.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelDbContext _context;
        private readonly UserManager<User> _userManager;
        public HotelController(HotelDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            HotelViewModel model = new HotelViewModel()
            {
                HotelInfos = await _context.HotelInfos.Where(h => !h.IsDeleted).ToListAsync(),
                HotelCategories = await _context.HotelCategories.ToListAsync(),
            };
            return View(model);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var hotels = await _context.HotelInfos
                .Include(h => h.Children)
                .Include(h=>h.HotelCategory)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (hotels == null)
            {
                return NotFound();
            }
            return View(hotels);
        }
    }
}
