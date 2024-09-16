using Microsoft.AspNetCore.Mvc;
using MusicStoreApplication.Domain.Domain.Integration;
using MusicStoreApplication.Domain.DTO;
using Newtonsoft.Json;

namespace MusicStoreApplication.Web.Controllers.Integration
{
    public class PartnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DisplayPartnerTracks()
        {
            List<PartnerTrackDto> partnerTrackDtos = new List<PartnerTrackDto>();

            HttpClient client = new HttpClient();
            string URL = "http://localhost:5004/Partner/ReturnPartnerTrackDTO";

            var json = client.GetStringAsync(URL);

            List<PartnerTrackDto> result = JsonConvert.DeserializeObject<List<PartnerTrackDto>>(json.Result) ?? new List<PartnerTrackDto>();

            return View("Index", result);
        }
    }
}
