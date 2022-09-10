using System;
using FreezeDanceTouring.Data.Data;

namespace FreezeDanceTouring.MVC.Models.TourModel
{
    public class TourDetails
    {
        public int Id { get; set; }
        public string Name{ get; set; }

        public List<Venue> Venues { get; set; } = new List<Venue>();
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}

