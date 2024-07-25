using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.IRepository.Interface;
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
        private readonly IRepository<Artist> _artistRepository;
        public ArtistService(IRepository<Artist> artistRepository)
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
    }
}
