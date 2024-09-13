using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.DTO
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
