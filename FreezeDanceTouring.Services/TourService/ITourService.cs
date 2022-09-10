using System;
using FreezeDanceTouring.MVC.Models.TourModel;

namespace FreezeDanceTouring.Services.TourService
{
    public interface ITourService
    {
        Task<bool> CreateTour(TourCreate model);
        Task<IEnumerable<TourListItem>> GetTourList();
        Task<TourDetails> GetTourDetails(int id);
        Task<bool> UpdateTour(int id, TourEdit model);
        Task<bool> DeleteTour(int id);
    }
}

