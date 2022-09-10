using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreezeDanceTouring.Data.Data.Entities
{
    public class Venue_Tour
    {
        public int Id { get; set; }

        public int VenueId { get; set; }
        [ForeignKey(nameof(VenueId))]
        public Venue Venue { get; set; }

        public int TourId { get; set; }
        [ForeignKey(nameof(TourId))]
        public Tour Tour { get; set; }
    }
}

