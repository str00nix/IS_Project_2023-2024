using AdminApplication.Models;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdminApplication.Controllers
{
    public class AlbumController : Controller
    {
        public AlbumController()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        string BaseUrl = "https://musicstoreapplicationweb20240916150058.azurewebsites.net";
        string LocalBaseUrl = "https://localhost:5027";
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = BaseUrl + "/api/Admin/GetAllAlbums";
            HttpResponseMessage response = client.GetAsync(URL).Result;

            var data = response.Content.ReadAsAsync<List<Album>>().Result;
            return View(data);
        }

        public IActionResult Details(Guid Id)
        {
            HttpClient client = new HttpClient();
            string URL = BaseUrl + "/api/Admin/GetAlbumDetails/{id}".Replace("{id}", Id.ToString());
            HttpResponseMessage response = client.GetAsync(URL).Result;

            var data = response.Content.ReadAsAsync<Album>().Result;
            //HttpClient client = new HttpClient();
            //string URL = "http://localhost:5027/api/Admin/GetAllAlbumDetails";

            //HttpContent content = new StringContent(JsonConvert.SerializeObject(trackDTOs), Encoding.UTF8, "application/json");

            //HttpResponseMessage response = client.PostAsync(URL, content).Result;

            return View(data);
        }

        public FileContentResult ExportAlbumDetailsToPdf(Guid Id)
        {
            HttpClient client = new HttpClient();
            string URL = BaseUrl + "/api/Admin/GetAlbumDetails/{id}".Replace("{id}", Id.ToString());
            HttpResponseMessage response = client.GetAsync(URL).Result;

            Album data = response.Content.ReadAsAsync<Album>().Result;

            if (data != null)
            {
                var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "AlbumDetails.docx");
                var document = DocumentModel.Load(templatePath);
                document.Content.Replace("{{AlbumName}}", data.Name);
                document.Content.Replace("{{ArtistsNames}}", String.Join(", ", data.Tracks.SelectMany(t => t.Artists.Select(at => at.Artist.Name)).ToHashSet().ToList()));


                StringBuilder sb = new StringBuilder();
                var total = 0;
                foreach (Track track in data.Tracks)
                {
                    sb.Append(track.Name).Append(" by ").Append(String.Join(", ", track.Artists.Select(at => at.Artist.Name)));
                    sb.Append("| Genres: ").Append(String.Join(", ", track.Genres.Select(gt => gt.Genre.Name).ToHashSet().ToList()));
                    sb.Append("\n");
                }
                document.Content.Replace("{{TrackList}}", sb.ToString());

                var stream = new MemoryStream();
                document.Save(stream, new PdfSaveOptions());
                return File(stream.ToArray(), new PdfSaveOptions().ContentType, "AlbumDetailsFor{Name}.pdf".Replace("{Name}", data.Name));
            }

            return null;
        }

    }
}
