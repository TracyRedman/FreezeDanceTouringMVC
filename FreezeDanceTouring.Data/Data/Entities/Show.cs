using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreezeDanceTouring.Data.Data
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime ShowDate { get; set; }
        public decimal Price { get; set; }

        public int VenueId { get; set; }
        [ForeignKey(nameof(VenueId))]
        public Venue Venue { get; set; }

        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}

