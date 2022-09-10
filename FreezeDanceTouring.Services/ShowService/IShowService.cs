using System;
using FreezeDanceTouring.MVC.Models.ShowModel;

namespace FreezeDanceTouring.Services.ShowService
{
    public interface IShowService
    {
        Task<bool> CreateShow(ShowCreate model);
        Task<IEnumerable<ShowListItem>> GetShowList();
        Task<ShowDetails> GetShowDetails(int id);
        Task<bool> UpdateShow(int id, ShowEdit model);
        Task<bool> DeleteShow(int id);
    }
}

