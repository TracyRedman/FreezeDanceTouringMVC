using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreezeDanceTouring.MVC.Models.ArtistModel;
using FreezeDanceTouring.MVC.Models.ShowModel;
using FreezeDanceTouring.Services.AgentService;
using FreezeDanceTouring.Services.ArtistService;
using FreezeDanceTouring.Services.ShowService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreezeDanceTouring.MVC.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _artService;
        private readonly IAgentService _agentService;
        private readonly IShowService _showService;

        public ArtistController(IArtistService artService,
            IAgentService agentService,
            IShowService showService)
        {
            _artService = artService;
            _agentService = agentService;
            _showService = showService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var artists = await _artService.GetArtistList();
            return View(artists);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var artist = await _artService.GetArtistDetails(id.Value);
            if (artist == null) return NotFound();
            return View(artist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ArtistDetails model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _artService.GetArtistDetails(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ArtistCreate model = new ArtistCreate();
            model.AgentListings = _agentService.GetAgentList().Result.Select(a => new SelectListItem
            {
                Text = $"{a.FirstName} {a.LastName}",
                Value = a.Id.ToString()
            });

            model.ShowListings = _showService.GetShowList().Result.Select(a => new SelectListItem
            {
                Text = a.VenueName,
                Value = a.Id.ToString()
            });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtistCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _artService.CreateArtist(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var artist = await _artService.GetArtistDetails(id.Value);
            if (artist == null) return NotFound();
            var artistEdit = new ArtistEdit
            {
                AgentId = artist.AgentId,
                Id = artist.Id,
                Label = artist.Label,
                Name = artist.Name
            };

            artistEdit.AgentListings = _agentService.GetAgentList().Result.Select(a => new SelectListItem
            {
                Text = $"{a.FirstName} {a.LastName}",
                Value = a.Id.ToString()
            });

            return View(artistEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, ArtistEdit model)
        {
            if (id != model.Id || !ModelState.IsValid) return BadRequest(ModelState);

            if (await _artService.UpdateArtist(id, model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var artist = await _artService.GetArtistDetails(id.Value);
            if (artist == null) return NotFound();
            return View(artist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _artService.DeleteArtist(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}

