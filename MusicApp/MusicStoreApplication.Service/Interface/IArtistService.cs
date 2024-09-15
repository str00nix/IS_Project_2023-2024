using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Interface
{
    public interface IArtistService
    {
        public List<Artist> GetArtists();
        public PagedSortedList<Artist> GetArtistsPaginated(string? searchString = null, string[]? genreSelect = null, 
                                                           int page = 1, int pageSize = 15, 
                                                           SortOrder sortOrder = SortOrder.Ascending, string? sortBy = null);
        public Artist? GetArtistById(Guid id);
        public Artist CreateNewArtist(Artist artist);
        public Artist UpdateArtist(Artist artist);
        public Artist DeleteArtist(Guid id);
    }
}
