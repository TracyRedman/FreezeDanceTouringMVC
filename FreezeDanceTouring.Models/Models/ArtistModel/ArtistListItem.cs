using System;
using System.ComponentModel.DataAnnotations;

namespace FreezeDanceTouring.MVC.Models.ArtistModel
{
    public class ArtistListItem
    {
        [Key]
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string Label { get; set; }
        public int ArtistId { get; set; }
    }
}

