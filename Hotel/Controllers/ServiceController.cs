using Hotel.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class ServiceController : Controller
    {
        private HotelDbContext _context;
        public ServiceController(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Service()
        {
            var service = await _context.Services.Where(s => !s.IsDeleted).ToListAsync();
            return View(service);
        }
    }
}
