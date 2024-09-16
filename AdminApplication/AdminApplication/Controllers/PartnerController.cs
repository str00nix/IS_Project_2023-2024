using AdminApplication.Models;
using AdminApplication.Models.Integration.ConversionObject;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminApplication.Controllers
{
    public class PartnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet, ActionName("ImportPartnerTracksAsJSON"), Produces("application/json")]
        public async Task<List<AdminApplication.Models.Integration.Track>> ImportPartnerTracksAsJSON()
        {
            HttpClient client = new HttpClient();

            string URL = "http://localhost:5073/Tracks/GetAllTracks";

            var json = await client.GetStringAsync(URL);

            List<AdminApplication.Models.Integration.Track>? result = JsonConvert.DeserializeObject<List<AdminApplication.Models.Integration.Track>>(json);

            return result;
        }

        [HttpGet, ActionName("ReturnPartnerTrackDTO")]
        public async Task<List<PartnerTrackDto>?> ReturnPartnerTrackDTO()
        {
            List<AdminApplication.Models.Integration.Track> partnerTracks = ImportPartnerTracksAsJSON().Result;

            List<PartnerTrackDto> partnerTrackDtoList = new List<PartnerTrackDto>();

            foreach (var partnerTrack in partnerTracks)
            {
                PartnerTrackDto tempPartnerTrackDto = new PartnerTrackDto() { 
                    Name = partnerTrack.TrackName,
                    ArtistNames = partnerTrack.Artists != null && partnerTrack.Artists.Count() > 0 ? partnerTrack.Artists.Select(x => x.Artist.ArtistName).ToList() : new List<string>(),
                    AlbumName = partnerTrack.Album != null ? partnerTrack.Album.AlbumName : "",
                    DurationInSeconds = partnerTrack.Duration.TotalSeconds,
                    Rating = partnerTrack.Rating
                };
                partnerTrackDtoList.Add(tempPartnerTrackDto);
            }

            return partnerTrackDtoList;
        }

    }
}
