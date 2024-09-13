using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using AdminApplication.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AdminApplication.Controllers
{
    public class TrackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Import")]
        public async Task<IActionResult> ImportTracksFromCSV([FromForm] IFormFile formFile)
        {
            List<CSVLineDTO> trackDTOs = getAllTrackInfoFromCSVFile(formFile);

            HttpClient client = new HttpClient();
            string URL = "http://localhost:5027/api/Admin/ImportTracksFromCSV";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(trackDTOs), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;
            //var result = response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Track");
        }

        public List<CSVLineDTO> getAllTrackInfoFromCSVFile(IFormFile formFile) {
            Console.WriteLine("Service method for track import called");

            using var reader = new StreamReader(formFile.OpenReadStream());

            List<CSVLineDTO> trackDTOs = new List<CSVLineDTO>();

            var content = reader.ReadLine(); //dummy for CSV headers
            while (reader.EndOfStream == false)
            {
                content = reader.ReadLine();

                content = Regex.Replace(content, @",(?!(([^""]*""){2})*[^""]*$)", "，").Replace("\"\"", "\"");

                try
                {
                    var parts = content.Split(',').ToList();

                    if (parts.All(x => x.Length > 0))
                    {
                        //artists,album_name,track_name,duration_ms,track_genre
                        CSVLineDTO tempTrackDTO = new CSVLineDTO() {
                            ArtistNames = new List<string>(parts[0].Split(';')),
                            AlbumName = parts[1].Replace("，", ", "),
                            TrackName = parts[2].Replace("，", ", "),
                            Duration_MS = double.Parse(parts[3]),
                            Genre = parts[4],
                        };

                        trackDTOs.Add(tempTrackDTO);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(content);
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            return trackDTOs;
        }

    }
}
