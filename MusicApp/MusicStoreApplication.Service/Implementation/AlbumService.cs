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
    public class AlbumService : IAlbumsService
    {
        private readonly IRepository<Album> _albumRepository;

        public AlbumService(IRepository<Album> albumRepository)
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

        public Album UpdateNewAlbum(Album album)
        {
            return _albumRepository.Update(album);
        }
    }
}
