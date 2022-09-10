using System;
using FreezeDanceTouring.Data.Data;
using FreezeDanceTouring.MVC.Models.TicketModel;
using Microsoft.EntityFrameworkCore;

namespace FreezeDanceTouring.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTicket(TicketCreate model)
        {
            var entity = new Ticket
            {
                Id = model.Id,
                ShowId = model.ShowId,
                Price = model.Price
            };
            await _context.Tickets.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return false;

            _context.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TicketDetails> GetTicketDetails(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return null;

            return new TicketDetails
            {
                Id = ticket.Id,
                ShowId = ticket.ShowId,
                Price = ticket.Price
            };
        }

        public async Task<IEnumerable<TicketListItem>> GetTicketList()
        {
            var tickets = await _context.Tickets.Select(t => new TicketListItem
            {
                Id = t.Id
            }).ToListAsync();

            return tickets;
        }

        public async Task<bool> UpdateTicket(int id, TicketEdit model)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return false;

            ticket.ShowId = model.ShowId;
            ticket.Price = model.Price;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

