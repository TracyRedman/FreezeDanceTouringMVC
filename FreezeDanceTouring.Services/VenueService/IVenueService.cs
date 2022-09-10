using System;
using FreezeDanceTouring.MVC.Models.VenueModel;

namespace FreezeDanceTouring.Services.VenueService
{
    public interface IVenueService
    {
        Task<bool> CreateVenue(VenueCreate model);
        Task<IEnumerable<VenueListItem>> GetVenueList();
        Task<VenueDetails> GetVenueDetails(int id);
        Task<bool> UpdateVenue(int id, VenueEdit model);
        Task<bool> DeleteVenue(int id);
    }
}

