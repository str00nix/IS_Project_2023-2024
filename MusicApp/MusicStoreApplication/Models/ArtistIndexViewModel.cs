using MusicStoreApplication.Domain.Domain;

namespace MusicStoreApplication.Web.Models
{
    public class ArtistIndexViewModel
    {
        public PagedSortedList<Artist> Artists;
        public IEnumerable<Genre> Genres;

        public ArtistIndexViewModel(
            PagedSortedList<Artist> artists,
            IEnumerable<Genre> genres
        )
        {
            Artists = artists;
            Genres = genres;
        }

        public ArtistIndexViewModel()
        {
            Artists = new PagedSortedList<Artist>();
            Genres = new List<Genre>();
        }
    }
}
