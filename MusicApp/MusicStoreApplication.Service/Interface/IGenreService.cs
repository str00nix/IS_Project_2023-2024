using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Interface
{
    public interface IGenreService
    {
        public List<Genre> GetGenres();
        public Genre? GetGenreById(Guid id);
        public Genre CreateNewGenre(Genre genre);
        public Genre UpdateGenre(Genre genre);
        public Genre DeleteGenre(Guid id);
    }
}
