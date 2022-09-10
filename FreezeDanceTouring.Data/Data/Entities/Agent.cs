using System;
using System.ComponentModel.DataAnnotations;

namespace FreezeDanceTouring.Data.Data
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Artist> Artists { get; set; } = new List<Artist>();
        public string AgentName
        {
            get { return $"{FirstName} {LastName}"; }

        }
    }
}