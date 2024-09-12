using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.Models
{
    public class ArtistOfTrack : BaseEntity
    {
        public Guid TrackId { get; set; }
        public Track? Track { get; set; }
        public Guid ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
