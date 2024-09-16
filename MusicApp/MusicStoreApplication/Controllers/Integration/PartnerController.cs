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

        string BaseUrl = "https://musicstoreadminapplication20240916155949.azurewebsites.net";
        [HttpGet]
        public IActionResult DisplayPartnerTracks()
        {
            List<PartnerTrackDto> partnerTrackDtos = new List<PartnerTrackDto>();

            HttpClient client = new HttpClient();
            string URL = BaseUrl + "/Partner/ReturnPartnerTrackDTO";

            var json = client.GetStringAsync(URL);

            List<PartnerTrackDto> result = JsonConvert.DeserializeObject<List<PartnerTrackDto>>(json.Result) ?? new List<PartnerTrackDto>();

            return View("Index", result);
        }
    }
}
