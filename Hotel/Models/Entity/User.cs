using Hotel.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
