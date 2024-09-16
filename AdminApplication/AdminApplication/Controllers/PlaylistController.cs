using AdminApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AdminApplication.Controllers
{
    public class PlaylistController : Controller
    {
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

    }
}
