using System;
using FreezeDanceTouring.Data.Data;
using FreezeDanceTouring.MVC.Models.VenueModel;
using Microsoft.EntityFrameworkCore;

namespace FreezeDanceTouring.Services.VenueService
{
    public class VenueService : IVenueService
    {
        private ApplicationDbContext _context;
        public VenueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVenue(VenueCreate model)
        {
            var entity = new Venue
            {
                Name = model.Name,
                City = model.City,
                State = model.State
            };
            await _context.Venues.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVenue(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null) return false;

            _context.Remove(venue);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<VenueDetails> GetVenueDetails(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null) return null;

            return new VenueDetails
            {
                Id = venue.Id,
                Name = venue.Name,
                City = venue.City,
                State = venue.State,
                Shows = venue.Shows,
                Capacity = venue.Capacity
            };
        }

        public async Task<IEnumerable<VenueListItem>> GetVenueList()
        {
            var venue = await _context.Venues.Select(v => new VenueListItem
            {
                Id = v.Id,
                Name = v.Name,
                City = v.City,
                State = v.State
            }).ToListAsync();

            return venue;
        }

        public async Task<bool> UpdateVenue(int id, VenueEdit model)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null) return false;

            venue.Capacity = model.Capacity;
            venue.Name = model.Name;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

