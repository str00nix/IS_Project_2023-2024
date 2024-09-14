using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.DTO
{
    public class TrackDto
    {
        public string Name { get; set; }
        public double DurationInMilliseconds { get; set; }
        public List<Guid> GenreIds { get; set; }
        public List<Guid> ArtistIds { get; set; }
        public Guid AlbumId { get; set; }
    }
}
