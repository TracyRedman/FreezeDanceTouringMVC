using System;
using FreezeDanceTouring.Data.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreezeDanceTouring.MVC.Models.ShowModel
{
    public class ShowEdit
    {
        public int Id { get; set; }
        public DateTime ShowDate { get; set; }
        public decimal Price { get; set; }
        public string VenueName { get; set; }

        public int VenueId { get; set; }

        public List<Artist> Artists { get; set; } = new List<Artist>();

        [ValidateNever]
        public IEnumerable<SelectListItem> VenueListings { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ArtistListings { get; set; }
    }
}

