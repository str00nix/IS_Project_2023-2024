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
        [HttpPost("[action]")]
        public Album GetAlbumDetails(BaseEntity baseEntity)
        {
            return _albumService.GetAlbumById(baseEntity.Id);
        }
        [HttpGet("[action]")]
        public List<PlaylistDTO> GetAllPlaylistDTOs()
        {
            return _playlistService.GetPlaylistDTOs();
        }
    }
}
