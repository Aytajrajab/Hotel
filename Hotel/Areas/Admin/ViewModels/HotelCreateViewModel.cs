using Hotel.Models.Entity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Hotel.Areas.Admin.ViewModels
{
    public class HotelCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? HotelCategoryId { get; set; }
        public IFormFile[] Files { get; set; }
        public List<HotelCategory> HotelCategories { get; set; }
        
    }
}
