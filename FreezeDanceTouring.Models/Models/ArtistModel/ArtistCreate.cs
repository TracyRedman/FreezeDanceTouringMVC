using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreezeDanceTouring.MVC.Models.ArtistModel
{
    public class ArtistCreate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int? ShowId { get; set; }
        public int AgentId { get; set; }
   
        [ValidateNever]
        public IEnumerable<SelectListItem> ShowListings { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AgentListings { get; set; }

    }
}

