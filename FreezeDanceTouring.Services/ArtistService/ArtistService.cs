using System;
using FreezeDanceTouring.Data.Data;
using FreezeDanceTouring.MVC.Models.ArtistModel;
using Microsoft.EntityFrameworkCore;

namespace FreezeDanceTouring.Services.ArtistService
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _context;

        public ArtistService (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateArtist(ArtistCreate model)
        {
            var entity = new Artist
            {
                Name = model.Name,
                Label = model.Label,
                AgentId = model.AgentId,
                ShowId = model.ShowId
            };
            await _context.Artists.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null) return false;

            _context.Remove(artist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ArtistDetails> GetArtistDetails(int id)
        {
            var artist = await _context.Artists.Include(s => s.Show).Include(s => s.Agent)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (artist == null) return null;

            ////var artists = await _context.Shows.Where(art => art.Id == artist.Id).Select(s =>new ArtistListItem
            //{
            //    Id = artist.Id,
            //    ArtistName = artist.Name
            //}).ToListAsync();

            if (artist is null) return null;

            return new ArtistDetails
            {
                Id = artist.Id,
                Name = artist.Name,
                Label = artist.Label,
                AgentName = artist.Agent.AgentName,
                AgentId = artist.AgentId,
                ShowDate = artist.Show.ShowDate,
            };
        }

        public Task<bool> GetArtistDetails(ArtistDetails model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArtistListItem>> GetArtistList()
        {
            var artists = await _context.Artists.Select(a => new ArtistListItem
            {
                Id = a.Id,
                ArtistName = a.Name
            }).ToListAsync();

            return artists;
        }

        public async Task<bool> UpdateArtist(int id, ArtistEdit model)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null) return false;

            artist.Name = model.Name;
            artist.AgentId = model.AgentId;
            artist.Label = model.Label;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

