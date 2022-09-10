using System;
using FreezeDanceTouring.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreezeDanceTouring.MVC.Models.ShowModel
{
    public class ShowDetails
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime ShowDate { get; set; }
        public decimal Price { get; set; }
        public Venue Venue { get; set; }

        public string VenueName { get; set; }

        public int VenueId { get; set; }
        public int ArtistId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ArtistListings { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> VenueListings { get; set; }

        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}

