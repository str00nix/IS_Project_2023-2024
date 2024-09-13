using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;

namespace MusicStoreApplication.Web.Models
{
    public class TrackCreateViewModel
    {
        public Track? Track;
        public TrackDto TrackDto;
        public List<Artist> Artists;
        public List<Album> Albums;

        public TrackCreateViewModel(
            Track track, 
            TrackDto trackDto, 
            List<Artist> artists,
            List<Album> albums
        )
        {
            Track = track;
            TrackDto = trackDto;
            Artists = artists;
            Albums = albums;
        }

        public TrackCreateViewModel()
        {
            Track = null;
            Artists = new List<Artist>();
            Albums = new List<Album>();
        }
    }
}
