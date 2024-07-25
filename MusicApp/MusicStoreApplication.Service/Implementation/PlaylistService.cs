using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Implementation
{
    public class PlaylistService : IPlaylistService
    {
        public Playlist CreateNewPlaylist(string userId, Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public Playlist DeletePlaylist(Guid id)
        {
            throw new NotImplementedException();
        }

        public Playlist GetPlaylistById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<Playlist> GetPlaylists()
        {
            throw new NotImplementedException();
        }

        public Playlist UpdatePlaylist(Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}
