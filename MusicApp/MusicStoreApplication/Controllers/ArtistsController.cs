using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Service.Interface;
using MusicStoreApplication.Web.Models;

namespace MusicStoreApplication.Web.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IGenreService _genreService;

        public ArtistsController(
            IArtistService artistService,
            IGenreService genreService
        )
        {
            _artistService = artistService;
            _genreService = genreService;
        }


        // GET: Artists
        public async Task<IActionResult> Index(
            [FromQuery] string? searchString, 
            [FromQuery] string[]? genreSelect, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 15, 
            [FromQuery] SortOrder sortOrder = SortOrder.Ascending, 
            [FromQuery] string? sortBy = null
        )
        {
            var model = new ArtistIndexViewModel();
            model.Genres = _genreService.GetGenres();

            //model.Albums = new PagedSortedList<Album>();
            //model.Albums.Items = _albumsService.GetAlbums();
            model.Artists = _artistService.GetArtistsPaginated(searchString, genreSelect, page, 
                                                               pageSize, sortOrder, sortBy);

            return View(model);
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetArtistById((Guid)id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                artist.Id = Guid.NewGuid();
                _artistService.CreateNewArtist(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetArtistById((Guid) id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _artistService.UpdateArtist(artist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.Id))
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
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetArtistById((Guid) id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var artist = _artistService.GetArtistById(id);
            if (artist != null)
            {
                _artistService.DeleteArtist(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(Guid id)
        {
            return _artistService.GetArtistById(id) != null;
        }
    }
}
