using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;
using System;
using System.Collections.Generic;

namespace MusicStoreApplication.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITrackService _trackService;
        private readonly IAlbumService _albumService;
        private readonly IPlaylistService _playlistService;

        public AdminController(ITrackService trackService, IAlbumService albumService, IPlaylistService playlistService)
        {
            _trackService = trackService;
            _albumService = albumService;
            _playlistService = playlistService;
        }

        [HttpGet("[action]")]
        public List<Track> GetAllTracks()
        {
            return _trackService.GetTracks();
        }
        
        [HttpPost("ImportTracksFromCSV")]
        public bool ImportTracksFromCSV(List<CSVLineDTO> model) {
            bool status = true;

            _trackService.ExtractTracksFromCSVDTOs(model);

            return status;
        }
        [HttpGet("[action]")]
        public List<Album> GetAllAlbums()
        {
            return _albumService.GetAlbums();
        }
        [HttpGet("GetAlbumDetails/{id}")]
        public Album GetAlbumDetails(Guid? id)
        {
            if (id == null)
                return null;

            return _albumService.GetAlbumById((Guid) id);
        }
        [HttpGet("[action]")]
        public List<PlaylistDTO> GetAllPlaylistDTOs()
        {
            return _playlistService.GetPlaylistDTOs();
        }
        [HttpGet("[action]")]
        public List<Playlist> GetAllPlaylists()
        {
            return _playlistService.GetPlaylists();
        }
        [HttpGet("GetPlaylistDetails/{id}")]
        public Playlist GetPlaylistDetails(Guid? id)
        {
            if (id == null)
                return null;

            return _playlistService.GetPlaylistById((Guid)id);
        }
    }
}
