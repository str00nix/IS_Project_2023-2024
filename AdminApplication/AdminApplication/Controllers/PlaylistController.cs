using AdminApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdminApplication.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost, ActionName("Export"), Produces("application/json")]
        //public async Task<JsonResult> ExportPlaylistsAsJSON()
        //{
        //    List<Playlist> playlists = new List<Playlist>();

        //    HttpClient client = new HttpClient();
            
        //    string URL = "http://localhost:5027/api/Admin/GetAllPlaylistDTOs";

        //    HttpResponseMessage response = client.GetAsync(URL).Result;

        //    //HttpContent content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json");
        //    //playlists = content;
        //    //var result = response.Content.ReadAsAsync<bool>().Result;

        //    return Ok(content);
        //}

    }
}
