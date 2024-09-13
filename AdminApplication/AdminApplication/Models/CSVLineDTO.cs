using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.Models
{
    public class CSVLineDTO
    {
        List<string> ArtistNames { get; set; }
        string AlbumName { get; set; }
        string TrackName { get; set; }
        double Duration_MS { get; set; }
        string Genre { get; set; }
    }
}
