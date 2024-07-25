using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Interface
{
    public interface IPlaylistService
    {
        public List<Playlist> GetPlaylists();
        public Playlist GetPlaylistById(Guid? id);
        public Playlist CreateNewPlaylist(string userId, Playlist playlist);
        public Playlist UpdatePlaylist(Playlist playlist);
        public Playlist DeletePlaylist(Guid id);
    }
}
