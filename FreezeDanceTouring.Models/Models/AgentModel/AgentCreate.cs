using System;
using System.ComponentModel.DataAnnotations;

namespace FreezeDanceTouring.MVC.Models.AgentModel
{
    public class AgentCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}

