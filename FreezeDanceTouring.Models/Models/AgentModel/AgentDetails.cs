using System;
using FreezeDanceTouring.Data.Data;
using System.ComponentModel.DataAnnotations;

namespace FreezeDanceTouring.MVC.Models.AgentModel
{
    public class AgentDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
      
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}

