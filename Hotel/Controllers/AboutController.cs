using Hotel.DAL;
using Hotel.Models.Entity;
using Hotel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class AboutController : Controller
    {
        private HotelDbContext _context;
        public AboutController(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Service> services = await _context.Services.ToListAsync();
            List<Staff> staffs = await _context.Staffs.ToListAsync();

            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Staffs = staffs,
                Services = services,
            };
            return View(model);
        }
       
    }
}
