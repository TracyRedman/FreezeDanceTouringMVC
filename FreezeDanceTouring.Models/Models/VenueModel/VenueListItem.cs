using System;
using FreezeDanceTouring.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreezeDanceTouring.MVC.Models.VenueModel
{
    public class VenueListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}

