using Hotel.DAL;
using Hotel.Models.Entity;
using Hotel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class ContactController : Controller
    {
        private HotelDbContext _context;
        public ContactController(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ContactViewModel contactViewModel = new ContactViewModel()
            {
                Contacts = await _context.Contacts.Where(c => !c.IsDeleted).ToListAsync()
            };
            return View(contactViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Message message = new Message()
            {
                Name = model.Name,
                Email = model.Email,
                MessageContent = model.Message,
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
