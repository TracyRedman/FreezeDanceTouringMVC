using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreezeDanceTouring.MVC.Models.ShowModel;
using FreezeDanceTouring.Services.ArtistService;
using FreezeDanceTouring.Services.ShowService;
using FreezeDanceTouring.Services.TicketService;
using FreezeDanceTouring.Services.VenueService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreezeDanceTouring.MVC.Controllers
{
    public class ShowController : Controller
    {
        private readonly IArtistService _artService;
        private readonly ITicketService _tService;
        private readonly IShowService _sService;
        private readonly IVenueService _vService;

        public ShowController(IShowService sService,
            IArtistService artService,
            ITicketService tService,
            IVenueService vService)
        {
            _artService = artService;
            _sService = sService;
            _tService = tService;
            _vService = vService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shows = await _sService.GetShowList();
            return View(shows);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var show = await _sService.GetShowDetails(id.Value);
            if (show == null) return NotFound();
            return View(show);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ShowCreate model = new ShowCreate();
            model.VenueListings = _vService.GetVenueList().Result.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShowCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _sService.CreateShow(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var show = await _sService.GetShowDetails(id.Value);
            if (show == null) return NotFound();
            return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, ShowEdit model)
        {
            if (id != model.Id || !ModelState.IsValid) return BadRequest(ModelState);

            if (await _sService.UpdateShow(id, model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var show = await _sService.GetShowDetails(id.Value);
            if (show == null) return NotFound();
            return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _sService.DeleteShow(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}

