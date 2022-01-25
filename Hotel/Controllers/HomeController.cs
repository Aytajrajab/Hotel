using Hotel.DAL;
using Hotel.Models.Entity;
using Hotel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private HotelDbContext _context;
        public HomeController(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<CommentSection> comments = await _context.Comments.ToListAsync();
            List<HotelInfo> hotelInfos = await _context.HotelInfos.ToListAsync();
            List<Room> rooms = await _context.Rooms.ToListAsync();
            List<RoomImageSlider> roomImgs = await _context.RoomImages.ToListAsync();
            List<Service> services = await _context.Services.ToListAsync();
            List<Staff> staffs = await _context.Staffs.ToListAsync();

            HomeIndexViewModel model = new HomeIndexViewModel
            {
                Comments = comments,
                HotelInfos = hotelInfos,
                Rooms = rooms,
                Services = services,
                Staffs = staffs,
                RoomImages = roomImgs,

            };
            return View(model);
        }

        

        public async Task<IActionResult> Contact()
        {
            return View();
        }
        public async Task<IActionResult> Service()
        {
            return View();
        }


    }
}
