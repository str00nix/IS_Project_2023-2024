using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Interface
{
    public interface IAlbumService
    {
        public List<Album> GetAlbums();
        public PagedSortedList<Album> GetAlbumsPaginated(string? searchString = null, string[]? artistSelect = null, 
                                                         string[]? genreSelect = null, int page = 1, int pageSize = 15, 
                                                         SortOrder sortOrder = SortOrder.Ascending, string? sortBy = null);
        public Album? GetAlbumById(Guid id);
        public Album CreateNewAlbum(Album album);
        public Album UpdateNewAlbum(Album album);
        public Album DeleteAlbum(Guid id);
    }
}
