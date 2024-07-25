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
        public Album GetAlbumById(Guid? id);
        public Album CreateNewAlbum(Album album);
        public Album UpdateAlbum(Album album);
        public Album DeleteAlbum(Guid id);
    }
}
