using Hotel.DAL;
using Hotel.Models;
using Hotel.Models.Entity;
using Hotel.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        private readonly HotelDbContext _context;
        private readonly UserManager<User> _userManager; 
        public RoomController(HotelDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            RoomsViewModel model = new RoomsViewModel()
            {
                Rooms = await _context.Rooms.Where(h => !h.IsDeleted).ToListAsync(),
                RoomImages = await _context.RoomImages.ToListAsync(),
                RoomCategories = await _context.RoomCategories.ToListAsync(),
            };
            return View(model);
        }

        public async Task<IActionResult> Book(int? id)
        {
            if (id == null) return BadRequest();

            return View();

            BookingViewModel model = new BookingViewModel();

            var bookModel = new BookingViewModel()
            {
                RoomId = id.Value,
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut,
                Quantity = model.Quantity,
                Fee = model.Fee,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(BookingViewModel model, int? id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var room = await _context.Rooms.Where(r => r.Id == id).FirstOrDefaultAsync();
            var hotel = await _context.HotelInfos.Where(h => h.Id == room.Id).FirstOrDefaultAsync();
            var guest = new Guest()
            {
                Name = model.Guest.Name,
                Surname = model.Guest.Surname,
                Email = model.Guest.Email,
                Phone = model.Guest.Phone,
                User = user
            };

            var book = new Booking()
            {
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut,
                Guest = guest,
                HotelInfo = hotel,
                Room = room,
                Quantity = model.Quantity,
                Fee = room.Price,
                RoomId = id
            };

            await _context.Bookings.AddAsync(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
