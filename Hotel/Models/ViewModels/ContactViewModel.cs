using Hotel.Models.Entity;
using System.Collections.Generic;

namespace Hotel.Models.ViewModels
{
    public class ContactViewModel
    {
        public List<Contact> Contacts { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
