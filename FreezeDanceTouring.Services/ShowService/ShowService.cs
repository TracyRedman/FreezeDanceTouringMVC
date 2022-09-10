using System;
using FreezeDanceTouring.Data.Data;
using FreezeDanceTouring.MVC.Models.ArtistModel;
using FreezeDanceTouring.MVC.Models.ShowModel;
using Microsoft.EntityFrameworkCore;

namespace FreezeDanceTouring.Services.ShowService
{
    public class ShowService : IShowService
    {
        private readonly ApplicationDbContext _context;

        public ShowService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateShow(ShowCreate model)
        {
            var entity = new Show
            {
                VenueId = model.VenueId,
                ShowDate = model.ShowDate,
                Price = model.Price,
            };
            await _context.Shows.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteShow(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show == null) return false;

            _context.Remove(show);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ShowDetails> GetShowDetails(int id)
        {
            var show = await _context.Shows.Include(s => s.Venue).Include(s => s.Artists).SingleOrDefaultAsync(s => s.Id == id);
            if (show == null) return null;

            return new ShowDetails
            {
                Id = show.Id,
                Artists = show.Artists,
                VenueId = show.VenueId,
                Tickets = show.Tickets,
                ShowDate = show.ShowDate,
                Price = show.Price,
                Venue = show.Venue
            };
        }

        public async Task<IEnumerable<ShowListItem>> GetShowList()
        {
            var shows = await _context.Shows.Include(s => s.Venue).Select(a => new ShowListItem
            {
                Id = a.Id,
                VenueId = a.Venue.Id,
                VenueName = a.Venue.Name

            }).ToListAsync();

            return (IEnumerable<ShowListItem>)shows;
        }

        public async Task<bool> UpdateShow(int id, ShowEdit model)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show == null) return false;

            show.Artists = model.Artists;
            show.VenueId = model.VenueId;
            show.ShowDate = model.ShowDate;
            show.Price = model.Price;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

