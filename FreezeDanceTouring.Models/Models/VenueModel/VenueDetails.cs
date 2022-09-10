using System;
using FreezeDanceTouring.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreezeDanceTouring.MVC.Models.VenueModel
{
    public class VenueDetails
    {
         public int Id { get; set; }
         public int Capacity { get; set; }
         public string Name { get; set; }
         public string City { get; set; }
         public string State { get; set; }

         public int? TourId { get; set; }

         public List<Show> Shows { get; set; } = new List<Show>();
    }
}

