using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreezeDanceTouring.MVC.Models.AgentModel;
using FreezeDanceTouring.Services.AgentService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreezeDanceTouring.MVC.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _aService;

        public AgentController(IAgentService aService)
        {
            _aService = aService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var agents = await _aService.GetAgentList();
                return View(agents);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var agent = await _aService.GetAgentDetails(id.Value);
            if (agent == null) return NotFound();
            return View(agent);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgentCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _aService.CreateAgent(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var agent = await _aService.GetAgentDetails(id.Value);
            if (agent == null) return NotFound();
            return View(agent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, AgentEdit model)
        {
            if (id != model.Id || !ModelState.IsValid) return BadRequest(ModelState);

            if (await _aService.UpdateAgent(id, model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var agent = await _aService.GetAgentDetails(id.Value);
            if (agent == null) return NotFound();
            return View(agent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _aService.DeleteAgent(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}

