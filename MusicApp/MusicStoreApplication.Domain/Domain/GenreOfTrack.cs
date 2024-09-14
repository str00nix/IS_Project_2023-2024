using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain
{
    public class GenreOfTrack : BaseEntity
    {
        public Guid TrackId { get; set; }
        public Track? Track { get; set; }
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
