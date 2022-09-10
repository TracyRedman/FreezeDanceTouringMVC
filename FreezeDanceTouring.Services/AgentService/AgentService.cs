using System;
using FreezeDanceTouring.Data.Data;
using FreezeDanceTouring.MVC.Models.AgentModel;
using Microsoft.EntityFrameworkCore;

namespace FreezeDanceTouring.Services.AgentService
{
    public class AgentService : IAgentService
    {
        private readonly ApplicationDbContext _context;

        public AgentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAgent(AgentCreate model)
        {
            var entity = new Agent
            {
 
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
            await _context.Agents.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAgent(int id)
        {
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null) return false;

            _context.Remove(agent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AgentDetails> GetAgentDetails(int id)
        {
            var agent = await _context.Agents.Include(a => a.Artists).SingleOrDefaultAsync(x => x.Id == id);
            if (agent == null) return null;

            var agents = await _context.Artists.Where(ag => ag.AgentId == agent.Id).Select(a => new AgentListItem
            {
                Id = agent.Id,
                FirstName = agent.FirstName,
                LastName = agent.LastName,
                Email = agent.Email
               
            }).ToListAsync();

            if (agent is null) return null;

            return new AgentDetails
            {
                Id = agent.Id,
                FirstName = agent.FirstName,
                LastName = agent.LastName,
                Artists = agent.Artists,
                Email = agent.Email
            };
        }

        public async Task<IEnumerable<AgentListItem>> GetAgentList()
        {
            var agents = await _context.Agents.Include(a => a.Artists).Select(a => new AgentListItem
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email

            }).ToListAsync();

            return agents;
        }

        public async Task<bool> UpdateAgent(int id, AgentEdit model)
        {
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null) return false;

            agent.FirstName = model.FirstName;
            agent.LastName = model.LastName;
            agent.Email = model.Email;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

