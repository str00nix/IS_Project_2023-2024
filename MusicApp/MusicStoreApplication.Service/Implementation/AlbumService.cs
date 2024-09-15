using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Implementation
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public Album CreateNewAlbum(Album album)
        {
            return _albumRepository.Insert(album);
        }

        public Album DeleteAlbum(Guid id)
        {
            Album album = _albumRepository.Get(id);
            return _albumRepository.Delete(album);
        }

        public Album? GetAlbumById(Guid id)
        {
            return _albumRepository.Get(id);
        }

        public List<Album> GetAlbums()
        {
            return _albumRepository.GetAll().ToList();
        }

        public PagedSortedList<Album> GetAlbumsPaginated(string? searchString = null, string[]? artistSelect = null, string[]? genreSelect = null, int page = 1, int pageSize = 15, SortOrder sortOrder = SortOrder.Ascending, string? sortBy = null)
        {
            var albumsQuery = _albumRepository.GetAll().AsQueryable();


            if (searchString != null)
            {
                albumsQuery = albumsQuery.Where(t => t.Name.ToLower().Contains(searchString.ToLower()));
            }
            if (artistSelect != null && artistSelect.Length != 0)
            {
                albumsQuery = albumsQuery.Where(
                    a => a.Tracks.SelectMany(
                        t => t.Artists.Select(
                            at => at.Artist.Id
                            )
                        ).Where(
                            artistId => artistSelect.Contains(artistId.ToString())
                        ).Any()
                );
            }
            if (genreSelect != null && genreSelect.Length != 0)
            {
                albumsQuery = albumsQuery.Where(
                    a => a.Tracks.SelectMany(
                        t => t.Genres.Select(
                            at => at.Genre.Id
                            )
                        ).Where(
                            genreId => genreSelect.Contains(genreId.ToString())
                        ).Any()
                );
                //albumsQuery = albumsQuery.Where(t => t.Genres.Where(gt => genreSelect.Contains(gt.Genre.Name)).Any());
            }

            var totalCount = albumsQuery.Count();
            var totalPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);


            albumsQuery = albumsQuery.Skip((page - 1) * pageSize).Take(pageSize);

            var albums = albumsQuery.ToList();

            return new PagedSortedList<Album>
            {
                TotalPages = totalPages,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                SortBy = sortBy,
                SortOrder = sortOrder,
                Items = albums
            };
        }

        public Album UpdateNewAlbum(Album album)
        {
            return _albumRepository.Update(album);
        }
    }
}
