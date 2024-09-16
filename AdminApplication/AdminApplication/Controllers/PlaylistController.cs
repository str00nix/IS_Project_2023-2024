using AdminApplication.Models;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
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
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5027/api/Admin/GetAllPlaylists";
            HttpResponseMessage response = client.GetAsync(URL).Result;

            var data = response.Content.ReadAsAsync<List<Playlist>>().Result;
            return View(data);
        }

        public IActionResult Details(Guid Id)
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5027/api/Admin/GetPlaylistDetails/{id}".Replace("{id}", Id.ToString());
            HttpResponseMessage response = client.GetAsync(URL).Result;

            var data = response.Content.ReadAsAsync<Playlist>().Result;

            return View(data);
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

        [HttpGet, ActionName("ExportAsExcel")]
        public async Task<FileContentResult> ExportPlaylistsAsExcelSpreadsheet()
        {
            string fileName = "AllPlaylists.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var workBook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workBook.Worksheets.Add("Playlists");

                worksheet.Cell(1, 1).Value = "Playlist No.";
                worksheet.Cell(1, 2).Value = "Playlist Name";
                worksheet.Cell(1, 3).Value = "User ID";
                worksheet.Cell(1, 4).Value = "Username";
                worksheet.Cell(1, 5).Value = "Track Names";

                HttpClient client = new HttpClient();
                string URL = "http://localhost:5027/api/Admin/GetAllPlaylistDTOs";
                HttpResponseMessage response = client.GetAsync(URL).Result;

                var data = response.Content.ReadAsAsync<List<PlaylistDTO>>().Result;

                for (int i = 0; i < data.Count(); i++)
                {
                    var tempPlaylistDTO = data[i];
                    worksheet.Cell(i + 2, 1).Value = (i+1).ToString();
                    worksheet.Cell(i + 2, 2).Value = tempPlaylistDTO.PlaylistName;

                    List<string> tempUserDictKeys = new List<string>(tempPlaylistDTO.User.Keys);
                    worksheet.Cell(i + 2, 3).Value = tempUserDictKeys[0];
                    worksheet.Cell(i + 2, 4).Value = tempPlaylistDTO.User[tempUserDictKeys[0]];

                    for (int j = 0; j < tempPlaylistDTO.Tracks.Count(); j++)
                    {
                        List<string> tempTracksDictKeys = new List<string>(tempPlaylistDTO.Tracks[j].Keys);

                        worksheet.Cell(i + 2, 5).Value += tempPlaylistDTO.Tracks[j][tempTracksDictKeys[0]] + "; ";

                    }
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }

        }

        public FileContentResult ExportPlaylistInfoAsExcelSpreadsheet(Guid Id)
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5027/api/Admin/GetPlaylistDetails/{id}".Replace("{id}", Id.ToString());
            HttpResponseMessage response = client.GetAsync(URL).Result;

            Playlist data = response.Content.ReadAsAsync<Playlist>().Result;

            if (data != null)
            {
                string fileName = "PlaylistDetailsFor_" + Id.ToString
                    ()+ ".xlsx";
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                using (var workBook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workBook.Worksheets.Add("Playlists");

                    worksheet.Cell(1, 1).Value = "Track Id";
                    worksheet.Cell(1, 2).Value = "Track Name";
                    worksheet.Cell(1, 3).Value = "Artists";
                    worksheet.Cell(1, 4).Value = "Genres";
                    worksheet.Cell(1, 5).Value = "Album";
                    worksheet.Cell(1, 6).Value = "Duration";

                    List<TrackInPlaylist> trackInPlaylists = data?.TracksInPlaylist?.ToList() ?? new List<TrackInPlaylist>();

                    for (int i = 0; i < trackInPlaylists.Count(); i++)
                    {
                        var tempTrack = trackInPlaylists[i].Track;
                        worksheet.Cell(i + 2, 1).Value = tempTrack?.Id.ToString() ?? "";

                        worksheet.Cell(i + 2, 2).Value = tempTrack?.Name ?? "";

                        worksheet.Cell(i + 2, 3).Value = tempTrack?.Artists != null && tempTrack.Artists.Count() > 0 ? String.Join(", ", tempTrack.Artists.Select(x => x.Artist?.Name ?? "")) : "";

                        worksheet.Cell(i + 2, 4).Value = tempTrack?.Genres != null && tempTrack.Genres.Count() > 0 ? String.Join(", ", tempTrack.Genres.Select(x => x.Genre?.Name ?? "")) : "";

                        worksheet.Cell(i + 2, 5).Value = tempTrack?.Album?.Name ?? "";

                        worksheet.Cell(i + 2, 6).Value = tempTrack?.DurationInMilliseconds?.ToString() ?? "";
                    }

                    using (var stream = new MemoryStream())
                    {
                        workBook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }
            }

            return null;
        }

    }
}
