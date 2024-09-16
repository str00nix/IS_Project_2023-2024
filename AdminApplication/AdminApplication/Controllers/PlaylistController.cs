using AdminApplication.Models;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AdminApplication.Controllers
{
    public class PlaylistController : Controller
    {
        public PlaylistController()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, ActionName("ExportAsJson"), Produces("application/json")]
        public async Task<List<PlaylistDTO>?> ExportPlaylistsAsJSON()
        {
            HttpClient client = new HttpClient();

            string URL = "http://localhost:5027/api/Admin/GetAllPlaylistDTOs";

            var json = await client.GetStringAsync(URL);

            List<PlaylistDTO>? result = JsonConvert.DeserializeObject<List<PlaylistDTO>>(json);

            return result;
        }

        [HttpGet, ActionName("ExportAsExcel"), Produces("application/json")]
        public async Task<List<PlaylistDTO>?> ExportPlaylistsAsExcelSpreadsheet()
        {
            //HttpClient client = new HttpClient();

            //string URL = "http://localhost:5027/api/Admin/GetAllPlaylistDTOs";

            //var json = await client.GetStringAsync(URL);

            //List<PlaylistDTO>? result = JsonConvert.DeserializeObject<List<PlaylistDTO>>(json);

            //return result;

            return null;
        }

    }
}
