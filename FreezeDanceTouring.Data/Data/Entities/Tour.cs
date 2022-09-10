using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreezeDanceTouring.Data.Data.Entities;

namespace FreezeDanceTouring.Data.Data
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
      
        public List<Venue_Tour> Venues { get; set; } = new List<Venue_Tour>();
        public List<Artist_Tour> Artists { get; set; } = new List<Artist_Tour>();
    }
}

