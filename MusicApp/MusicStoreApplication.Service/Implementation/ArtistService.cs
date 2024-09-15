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
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public Artist CreateNewArtist(Artist artist)
        {
            return _artistRepository.Insert(artist);
        }

        public Artist DeleteArtist(Guid id)
        {
            Artist artist = _artistRepository.Get(id);
            return _artistRepository.Delete(artist);
        }

        public Artist? GetArtistById(Guid id)
        {
            return _artistRepository.Get(id);
        }

        public List<Artist> GetArtists()
        {
            return _artistRepository.GetAll().ToList();
        }

        public Artist UpdateArtist(Artist artist)
        {
            return _artistRepository.Update(artist);
        }

        public PagedSortedList<Artist> GetArtistsPaginated(
            string? searchString = null, string[]? genreSelect = null, 
            int page = 1, int pageSize = 15, 
            SortOrder sortOrder = SortOrder.Ascending, string? sortBy = null
        )
        {
            var artistQuery = _artistRepository.GetAll().AsQueryable();


            if (searchString != null)
            {
                artistQuery = artistQuery.Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
            }

            if (genreSelect != null && genreSelect.Length > 0)
            {
                artistQuery = artistQuery.Where(
                    a => a.Tracks
                        .Select(at => at.Track).SelectMany(t => t.Genres)
                        .Select(gt => gt.Genre.Id)
                        .Where(genreId => genreSelect.Contains(genreId.ToString())).Any()
                );
            }


            var totalCount = artistQuery.Count();
            var totalPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);


            artistQuery = artistQuery.Skip((page - 1) * pageSize).Take(pageSize);

            var artists = artistQuery.ToList();

            return new PagedSortedList<Artist>
            {
                TotalPages = totalPages,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                SortBy = sortBy,
                SortOrder = sortOrder,
                Items = artists
            };
        }
    }
}
