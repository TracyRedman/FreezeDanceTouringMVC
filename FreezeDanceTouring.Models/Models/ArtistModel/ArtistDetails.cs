using System;
using FreezeDanceTouring.Data.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreezeDanceTouring.MVC.Models.ArtistModel
{
    public class ArtistDetails
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string AgentName{ get; set; }
        public int AgentId { get; set; }
        public DateTime ShowDate { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>AgentListings { get; set; }


        //public int ArtistId { get; set; }
        //public string ArtistName { get; set; }

        //public List<Tour> Tours { get; set; } = new List<Tour>();
    }
}

