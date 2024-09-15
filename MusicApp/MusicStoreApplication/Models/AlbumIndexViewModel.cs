using MusicStoreApplication.Domain.Domain;

namespace MusicStoreApplication.Web.Models
{
    public class AlbumIndexViewModel
    {
        public PagedSortedList<Album> Albums;
        public IEnumerable<Artist> Artists;
        public IEnumerable<Genre> Genres;

        public AlbumIndexViewModel(
            PagedSortedList<Album> albums, 
            IEnumerable<Artist> artists,
            IEnumerable<Genre> genres
        )
        {
            Albums = albums;
            Artists = artists;
            Genres = genres;
        }

        public AlbumIndexViewModel()
        {
            Albums = new PagedSortedList<Album>();
            Artists = new List<Artist>();
            Genres = new List<Genre>();
        }
    }
}
