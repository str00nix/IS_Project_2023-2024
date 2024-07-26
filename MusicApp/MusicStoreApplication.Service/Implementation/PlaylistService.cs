using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Implementation;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Implementation
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public Playlist CreateNewPlaylist(Playlist playlist)
        {
            return _playlistRepository.Insert(playlist);
        }

        public Playlist DeletePlaylist(Guid id)
        {
            Playlist playlist = _playlistRepository.Get(id);
            return _playlistRepository.Delete(playlist);
        }

        public Playlist? GetPlayListById(Guid id)
        {
            return _playlistRepository.GetDetailsForPlaylist(id);
        }

        public List<Playlist> GetPlaylists()
        {
            return _playlistRepository.GetAllPlaylists();
        }

        public Playlist UpdatePlaylist(Playlist playlist)
        {
            return _playlistRepository.Update(playlist);
        }
    }
}
