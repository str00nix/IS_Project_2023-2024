using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;
using System;

namespace MusicStoreApplication.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public AdminController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet("[action]")]
        public List<Track> GetAllTracks()
        {
            return _trackService.GetTracks();
        }
        
        [HttpPost, ActionName("ImportTracksFromCSV")]
        public bool ImportTracksFromCSV(List<CSVLineDTO> model) {
            bool status = true;

            _trackService.ExtractTracksFromCSVDTOs(model);

            return status;
        }
    }
}
