using System;
using FreezeDanceTouring.MVC.Models.AgentModel;

namespace FreezeDanceTouring.Services.AgentService
{
    public interface IAgentService //this is where CRUD happens
    {
        Task<bool> CreateAgent(AgentCreate model);
        Task<IEnumerable<AgentListItem>> GetAgentList();
        Task<AgentDetails> GetAgentDetails(int id);
        Task<bool> UpdateAgent(int id, AgentEdit model);
        Task<bool> DeleteAgent(int id);
    }
}

