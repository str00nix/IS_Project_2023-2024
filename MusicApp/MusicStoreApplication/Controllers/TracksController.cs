using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
using MusicStoreApplication.Repository;
using MusicStoreApplication.Repository.Implementation;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;
using MusicStoreApplication.Web.Models;

namespace MusicStoreApplication.Web.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackService _trackService;
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        private readonly ILogger<TracksController> _logger;

        public TracksController(ITrackService trackService, IAlbumService albumService, IArtistService artistService, ILogger<TracksController> logger)
        {
            _trackService = trackService;
            _albumService = albumService;
            _artistService = artistService;
            _logger = logger;
        }

        // GET: Tracks
        public async Task<IActionResult> Index(
            [FromQuery] string? searchString, 
            [FromQuery] string[]? artistSelect, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 15, 
            [FromQuery] SortOrder sortOrder = SortOrder.Ascending, 
            [FromQuery] string? sortBy = null
        )
        {

            if (pageSize > 50) {
                pageSize = 50;
            }

            var tracks = _trackService.GetTracksPaginated(searchString, artistSelect, page, pageSize, sortOrder, sortBy);
            var artists = _artistService.GetArtists();

            var model = new TrackIndexViewModel(tracks, artists);
            return View(model);
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _trackService.GetTrackById((Guid)id);

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
            var model = new TrackCreateViewModel();
            model.Track = null;
            model.Artists = _artistService.GetArtists();
            model.Albums = _albumService.GetAlbums();
            return View(model);
        }

        //TODO: This should be deleted in the final version 
        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Genre,ArtistIds,AlbumId")] TrackDto trackDto)
        {
            var track = new Track();
            if (ModelState.IsValid)
            {
                track = _trackService.CreateNewTrackFromDTO(trackDto);
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

            var track = _trackService.GetTrackById((Guid)id);
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
                    _trackService.UpdateTrack(track);
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

            var track = _trackService.GetTrackById((Guid)id);
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
            var track = _trackService.GetTrackById(id);
            if (track != null)
            {
                _trackService.DeleteTrack(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(Guid id)
        {
            return _trackService.GetTrackById(id) != null;
        }

        [HttpPost, ActionName("Import")]
        public async Task<IActionResult> ImportTracksFromCSV([FromForm] IFormFile formFile)
        {
            Console.WriteLine("Tracks controller import function called");
            try
            {
                formFile = formFile ?? Request.Form.Files[0];
                var result = await _trackService.ImportTracks(formFile);

                if (result == null)
                {
                    return StatusCode(500, "Error occured while importing tracks from inserted CSV file");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception thrown during track import from CSV");
                return StatusCode(500, "Exception thrown while importing tracks from inserted CSV file");
            }
        }

    }
}
