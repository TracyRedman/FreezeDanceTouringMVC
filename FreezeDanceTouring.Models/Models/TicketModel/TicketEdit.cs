using System;
using FreezeDanceTouring.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreezeDanceTouring.MVC.Models.TicketModel
{
    public class TicketEdit
    {
        public int ShowId { get; set; }
        public decimal Price { get; set; }
    }
}

