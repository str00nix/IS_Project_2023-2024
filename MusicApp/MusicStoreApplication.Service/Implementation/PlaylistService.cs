using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
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
        private readonly ITrackRepository _trackRepository;

        public PlaylistService(IPlaylistRepository playlistRepository, ITrackRepository trackRepository)
        {
            _playlistRepository = playlistRepository;
            _trackRepository = trackRepository;
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

        public Playlist AddTrackToPlaylist(string playlistID, AddTrackToPlaylistDTO playlistDTO)
        {
            Guid? playlistGUID = new Guid(playlistID);
            Playlist tempPlaylist = _playlistRepository.Get(playlistGUID);

            if (tempPlaylist == null)
            {
                Track tempTrack = _trackRepository.Get(playlistDTO.TrackID);
                if(tempTrack != null)
                {
                    tempPlaylist.TracksInPlaylist.Add(new TrackInPlaylist {
                        TrackId = playlistDTO.TrackID,
                        Track = tempTrack,
                        PlaylistId = (Guid)playlistGUID,
                        Playlist = tempPlaylist
                    });

                    return _playlistRepository.Update(tempPlaylist);
                }
            }

            return null;

        }

    }
}
