using Hotel.DAL;
using Hotel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private HotelDbContext _context;
        public FooterViewComponent(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerView = await _context.Footers.ToListAsync();
            return View(footerView); 
        }
    }
}
