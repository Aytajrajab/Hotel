﻿using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
