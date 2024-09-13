using MusicStoreApplication.Domain.Domain;
using System.Collections;

namespace MusicStoreApplication.Web.Models
{
    public class TrackIndexViewModel
    {
        public PagedSortedList<Track> Tracks;
        public IEnumerable<Artist> Artists;

        public TrackIndexViewModel(PagedSortedList<Track> tracks, IEnumerable<Artist> artists)
        {
            Tracks = tracks;
            Artists = artists;
        }

        public TrackIndexViewModel()
        {
            Tracks = new PagedSortedList<Track>();
            Artists = new List<Artist>();
        }
    }
}
