using System;
using FreezeDanceTouring.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FreezeDanceTouring.MVC.Models.ShowModel
{
    public class ShowCreate
    {
        [Key]
        public int Id { get; set; }
        public int VenueId { get; set; }
   
        public DateTime ShowDate { get; set; }
        public decimal Price { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> VenueListings { get; set; }
    }
}

