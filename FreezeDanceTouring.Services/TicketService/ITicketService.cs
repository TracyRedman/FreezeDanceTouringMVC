using System;
using FreezeDanceTouring.MVC.Models.TicketModel;

namespace FreezeDanceTouring.Services.TicketService
{
    public interface ITicketService
    {
        Task<bool> CreateTicket(TicketCreate model);
        Task<IEnumerable<TicketListItem>> GetTicketList();
        Task<TicketDetails> GetTicketDetails(int id);
        Task<bool> UpdateTicket(int id, TicketEdit model);
        Task<bool> DeleteTicket(int id);
    }
}

