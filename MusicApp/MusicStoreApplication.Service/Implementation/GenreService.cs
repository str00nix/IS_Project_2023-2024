using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;

namespace MusicStoreApplication.Service.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _genreRepository;

        public GenreService(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Genre CreateNewGenre(Genre genre)
        {
            return _genreRepository.Insert(genre);
        }

        public Genre DeleteGenre(Guid id)
        {
            Genre genre = _genreRepository.Get(id);
            return _genreRepository.Delete(genre);
        }

        public Genre? GetGenreById(Guid id)
        {
            return _genreRepository.Get(id);
        }

        public List<Genre> GetGenres()
        {
            return _genreRepository.GetAll().ToList();
        }

        public Genre UpdateGenre(Genre genre)
        {
            return _genreRepository.Update(genre);
        }
    }
}
