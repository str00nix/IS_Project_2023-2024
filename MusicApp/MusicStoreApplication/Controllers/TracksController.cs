using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository;
using MusicStoreApplication.Repository.Interface;

namespace MusicStoreApplication.Web.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepository;

        public TracksController(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }



        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            var tracks = _trackRepository.GetAll();

            return View(tracks);
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _trackRepository.Get(id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        //TODO: This should be deleted in the final version 
        // GET: Tracks/Create
        public IActionResult Create()
        {
            return View();
        }

        //TODO: This should be deleted in the final version 
        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Genre,Id")] Track track)
        {
            if (ModelState.IsValid)
            {
                track.Id = Guid.NewGuid();
                _trackRepository.Insert(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        //TODO: This should be deleted in the final version 
        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _trackRepository.Get(id);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        //TODO: This should be deleted in the final version 
        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Genre,Id")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _trackRepository.Update(track);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        //TODO: This should be deleted in the final version 
        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _trackRepository.Get(id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        //TODO: This should be deleted in the final version 
        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var track = _trackRepository.Get(id);
            if (track != null)
            {
                _trackRepository.Delete(track);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(Guid id)
        {
            return _trackRepository.Get(id) != null;
        }
    }
}
