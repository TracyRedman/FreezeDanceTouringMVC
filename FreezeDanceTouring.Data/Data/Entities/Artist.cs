using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreezeDanceTouring.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreezeDanceTouring.Data.Data
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }

        public int AgentId { get; set; }
        [ForeignKey (nameof(AgentId))]
        public Agent Agent { get; set; }

        public int? ShowId { get; set; }
        [ForeignKey (nameof(ShowId))]
        public Show Show { get; set; }

        public List<Artist_Tour> Tours { get; set; } = new List<Artist_Tour>();

    }
}

