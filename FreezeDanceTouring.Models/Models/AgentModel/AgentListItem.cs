using System;
using System.ComponentModel.DataAnnotations;

namespace FreezeDanceTouring.MVC.Models.AgentModel
{
    public class AgentListItem
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

