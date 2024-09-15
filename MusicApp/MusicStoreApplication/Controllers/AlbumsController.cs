using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Service.Interface;
using MusicStoreApplication.Service.Implementation;
using MusicStoreApplication.Web.Models;

namespace MusicStoreApplication.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumsService;
        private readonly IArtistService _artistService;
        private readonly IGenreService _genreService;

        public AlbumsController(
            IAlbumService albumsService,
            IArtistService artistService,
            IGenreService genreService
        )
        {
            _albumsService = albumsService;
            _artistService = artistService;
            _genreService = genreService;
        }

        // GET: Albums
        public async Task<IActionResult> Index(
            [FromQuery] string? searchString, 
            [FromQuery] string[]? artistSelect, 
            [FromQuery] string[]? genreSelect, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 15, 
            [FromQuery] SortOrder sortOrder = SortOrder.Ascending, 
            [FromQuery] string? sortBy = null
        )
        {
            var model = new AlbumIndexViewModel();
            model.Artists = _artistService.GetArtists();
            model.Genres = _genreService.GetGenres();

            //model.Albums = new PagedSortedList<Album>();
            //model.Albums.Items = _albumsService.GetAlbums();
            model.Albums = _albumsService.GetAlbumsPaginated(searchString, artistSelect, 
                                                             genreSelect, page, pageSize, sortOrder, sortBy);

            return View(model);
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _albumsService.GetAlbumById((Guid)id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Album album)
        {
            if (ModelState.IsValid)
            {
                album.Id = Guid.NewGuid();
                _albumsService.CreateNewAlbum(album);
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _albumsService.GetAlbumById((Guid)id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _albumsService.UpdateNewAlbum(album);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!AlbumExists(album.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                        throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _albumsService.GetAlbumById((Guid)id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _albumsService.DeleteAlbum(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool AlbumExists(Guid id)
        //{
        //    return _context.Albums.Any(e => e.Id == id);
        //}
    }
}
