using System;
using FreezeDanceTouring.MVC.Models.ArtistModel;

namespace FreezeDanceTouring.Services.ArtistService
{
    public interface IArtistService
    {
        Task<bool> CreateArtist(ArtistCreate model);
        Task<IEnumerable<ArtistListItem>> GetArtistList();
        Task<ArtistDetails> GetArtistDetails(int id);
        Task<bool> UpdateArtist(int id, ArtistEdit model);
        Task<bool> DeleteArtist(int id);
        Task<bool> GetArtistDetails(ArtistDetails model);
    }
}

