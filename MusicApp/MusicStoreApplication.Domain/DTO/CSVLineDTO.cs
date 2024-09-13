using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.DTO
{
    public class CSVLineDTO
    {
        public List<string> ArtistNames { get; set; }
        public string AlbumName { get; set; }
        public string TrackName { get; set; }
        public double Duration_MS { get; set; }
        public string Genre { get; set; }
    }
}
