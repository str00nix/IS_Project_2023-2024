using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;

namespace MusicStoreApplication.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITrackService _trackService;
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        private readonly ILogger<TracksController> _logger;

        public AdminController(ITrackService trackService, IAlbumService albumService, IArtistService artistService, ILogger<TracksController> logger)
        {
            _trackService = trackService;
            _albumService = albumService;
            _artistService = artistService;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public List<Track> GetAllTracks()
        {
            return _trackService.GetTracks();
        }
    }
}
