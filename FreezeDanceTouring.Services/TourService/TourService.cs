using System;
using FreezeDanceTouring.Data.Data;
using FreezeDanceTouring.MVC.Models.TourModel;
using Microsoft.EntityFrameworkCore;

namespace FreezeDanceTouring.Services.TourService
{
    public class TourService : ITourService
    {
        private readonly ApplicationDbContext _context;

        public TourService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTour(TourCreate model)
        {
            var entity = new Tour
            {
                Id = model.Id,
                Name = model.Name
            };
            await _context.Tours.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTour(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null) return false;

            _context.Remove(tour);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TourDetails> GetTourDetails(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null) return null;

            return new TourDetails
            {
                Id = tour.Id,
                Name = tour.Name

            };
        }

        public async Task<IEnumerable<TourListItem>> GetTourList()
        {
            var tour = await _context.Tours.Select(t => new TourListItem
            {
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();

            return tour;
        }

        public async Task<bool> UpdateTour(int id, TourEdit model)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null) return false;

            tour.Id = model.Id;
            tour.Name = model.Name;


            await _context.SaveChangesAsync();
            return true;
        }
    }
}

