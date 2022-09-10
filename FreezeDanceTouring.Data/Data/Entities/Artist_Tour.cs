using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreezeDanceTouring.Data.Data.Entities
{
    public class Artist_Tour
    {
        public int Id { get; set; }

        public int ArtistId { get; set; }
        [ForeignKey(nameof(ArtistId))]
        public Artist Artist { get; set; }

        public int TourId { get; set; }
        [ForeignKey(nameof(TourId))]
        public Tour Tour { get; set; }
    }
}

