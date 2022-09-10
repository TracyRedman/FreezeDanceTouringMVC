using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreezeDanceTouring.Data.Data
{
    public class Ticket
    {
        public int Id { get; set; }

        public int ShowId { get; set; }
        [ForeignKey(nameof(ShowId))]
        public Show Show { get; set; }

        public decimal Price { get; set; }
        public DateTime ShowDate { get; set; }
    }
}

