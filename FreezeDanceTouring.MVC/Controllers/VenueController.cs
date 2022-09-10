using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreezeDanceTouring.Data.Data;
using FreezeDanceTouring.MVC.Models.VenueModel;
using FreezeDanceTouring.Services.VenueService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreezeDanceTouring.MVC.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueService _vService;
        public VenueController(IVenueService vService)
        {
            _vService = vService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var venues = await _vService.GetVenueList();
            return View(venues);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var venue = await _vService.GetVenueDetails(id.Value);
            if (venue == null) return NotFound();
            return View(venue);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VenueCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _vService.CreateVenue(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var venue = await _vService.GetVenueDetails(id.Value);
            if (venue == null) return NotFound();
            return View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, VenueEdit model)
        {
            if (id != model.Id || !ModelState.IsValid) return BadRequest(ModelState);

            if (await _vService.UpdateVenue(id, model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var venue = await _vService.GetVenueDetails(id.Value);
            if (venue == null) return NotFound();
            return View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _vService.DeleteVenue(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}

