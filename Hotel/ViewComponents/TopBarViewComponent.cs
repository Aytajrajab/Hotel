using Hotel.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hotel.ViewComponents
{
    public class TopBarViewComponent : ViewComponent
    {
        private HotelDbContext _context;
        public TopBarViewComponent(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topBar = await _context.TopBars.ToListAsync();
            return View(topBar);
        }
    }
}
