using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
using MusicStoreApplication.Repository;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;

namespace MusicStoreApplication.Web.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly IPlaylistService _playlistService;
        private readonly IUserRepository _userRepository;

        public PlaylistsController(IPlaylistService playlistService, IUserRepository userRepository)
        {
            _playlistService = playlistService;
            _userRepository = userRepository;

        }


        // GET: Playlists
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
            var result = _playlistService.GetPlaylists().Where(z => z.User != null ? z.User.Id.Equals(userId) : false);
            //var result = _playlistService.GetPlaylistsFromUser(userId ?? "");
            return View(result);
        }

        [Authorize]
        public IActionResult AddTrackToPlaylist(Guid Id)
        {
            var result = _playlistService.GetPlayListById(Id);
            if (result != null)
            {
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddTrackToPlaylist(AddTrackToPlaylistDTO model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _playlistService.AddTrackToPlaylist(userId, model);

            if (result != null)
            {
                return RedirectToAction("Index", "Playlists");
            }
            else {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult DeleteTrackFromPlaylist(AddTrackToPlaylistDTO model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _playlistService.RemoveTrackFromPlaylist(userId, model);

            if (result != null)
            {
                return RedirectToAction("Index", "Playlists");
            }
            else
            {
                return View(model);
            }
        }

        // GET: Playlists/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var playlist = _playlistService.GetPlayListById((Guid)id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // GET: Playlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
                playlist.User = _userRepository.Get(userId);
                _playlistService.CreateNewPlaylist(playlist);
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = _playlistService.GetPlayListById((Guid)id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _playlistService.UpdatePlaylist(playlist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.Id))
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
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = _playlistService.GetPlayListById((Guid) id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var playlist = _playlistService.GetPlayListById(id);
            if (playlist != null)
            {
                _playlistService.DeletePlaylist(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(Guid id)
        {
            return _playlistService.GetPlayListById(id) != null;
        }
    }
}
