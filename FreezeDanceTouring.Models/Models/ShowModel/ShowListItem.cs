using System;
using FreezeDanceTouring.Data.Data;
using FreezeDanceTouring.MVC.Models.VenueModel;

namespace FreezeDanceTouring.MVC.Models.ShowModel
{
    public class ShowListItem
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public string VenueName { get; set; }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public Artist Artist { get; set; }
    }
}

