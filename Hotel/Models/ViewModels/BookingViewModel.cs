using Hotel.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.ViewModels
{
    public class BookingViewModel
    {
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        public Guest Guest { get; set; }
        public int Quantity { get; set; }
        public int? RoomId { get; set; }
        public int Adult { get; set; }
        public int Kids { get; set; }
        public decimal Fee { get; set; }
        
    }
}
