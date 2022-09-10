using System;
using FreezeDanceTouring.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreezeDanceTouring.MVC.Models.VenueModel
{
    public class VenueEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
