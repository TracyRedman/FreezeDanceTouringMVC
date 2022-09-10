using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreezeDanceTouring.Data.Data.Entities;

namespace FreezeDanceTouring.Data.Data
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public List<Venue_Tour> Venues { get; set; } = new List<Venue_Tour>();

        public List<Show> Shows { get; set; } = new List<Show>();

    }
}

