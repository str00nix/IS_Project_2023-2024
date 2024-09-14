using MusicStoreApplication.Domain.Domain;
using System.Collections;

namespace MusicStoreApplication.Web.Models
{
    public class TrackIndexViewModel
    {
        public PagedSortedList<Track> Tracks;
        public IEnumerable<Artist> Artists;
        public IEnumerable<Genre> Genres;

        public TrackIndexViewModel(
            PagedSortedList<Track> tracks, 
            IEnumerable<Artist> artists,
            IEnumerable<Genre> genres
        )
        {
            Tracks = tracks;
            Artists = artists;
            Genres = genres;
        }

        public TrackIndexViewModel()
        {
            Tracks = new PagedSortedList<Track>();
            Artists = new List<Artist>();
            Genres = new List<Genre>();
        }
    }
}
