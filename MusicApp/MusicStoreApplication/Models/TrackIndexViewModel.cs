using MusicStoreApplication.Domain.Domain;
using System.Collections;

namespace MusicStoreApplication.Web.Models
{
    public class TrackIndexViewModel
    {
        public IEnumerable<Track> Tracks;
        public IEnumerable<Artist> Artists;

        public TrackIndexViewModel(IEnumerable<Track> tracks, IEnumerable<Artist> artists)
        {
            Tracks = tracks;
            Artists = artists;
        }

        public TrackIndexViewModel()
        {
            Tracks = new List<Track>();
            Artists = new List<Artist>();
        }
    }
}
