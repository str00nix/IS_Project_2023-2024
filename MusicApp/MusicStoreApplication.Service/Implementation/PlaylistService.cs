using Microsoft.EntityFrameworkCore.Storage;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
using MusicStoreApplication.Repository.Implementation;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Implementation
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IRepository<TrackInPlaylist> _trackInPlaylistRepository;
        private readonly ITrackRepository _trackRepository;

        public PlaylistService(IUserRepository userRepository, IPlaylistRepository playlistRepository, IRepository<TrackInPlaylist> trackInPlaylistRepository, ITrackRepository trackRepository)
        {
            _userRepository = userRepository;
            _playlistRepository = playlistRepository;
            _trackInPlaylistRepository = trackInPlaylistRepository;
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
            return _playlistRepository.Get(id);
        }

        public List<Playlist> GetPlaylists()
        {
            return _playlistRepository.GetAll().ToList();
        }

        public List<PlaylistDTO> GetPlaylistDTOs()
        {
            List<PlaylistDTO> playlistDTOs = new List<PlaylistDTO>();
            List<Playlist> tempPlaylists = _playlistRepository.GetAll().ToList();
            foreach (Playlist p in tempPlaylists) {

                List<Dictionary<string, string>> tempTracks = new List<Dictionary<string, string>>();

                foreach (TrackInPlaylist trackInPlaylist in p.TracksInPlaylist) {
                    
                    tempTracks.Add(
                        new Dictionary<string, string>() { { trackInPlaylist.TrackId.ToString(), trackInPlaylist.Track.Name } }
                        );
                }

                playlistDTOs.Add(new PlaylistDTO() {
                    PlaylistName = p.Name,
                    User = new Dictionary<string, string>() { {
                            p.User.Id, p.User.UserName }
                    },
                    Tracks = tempTracks
                });
            }
            return playlistDTOs;
        }

        public Playlist UpdatePlaylist(Playlist playlist)
        {
            return _playlistRepository.Update(playlist);
        }

        public Playlist AddTrackToPlaylist(string userId, AddTrackToPlaylistDTO playlistDTO)
        {

            if (userId != null) {

                var loggedInUser = _userRepository.Get(userId);

                var userPlaylists = loggedInUser?.MyPlaylists;

                Playlist? tempPlaylist = userPlaylists.Where(z => z.Id == playlistDTO.PlaylistID).FirstOrDefault();

                if (tempPlaylist != null)
                {
                    Track tempTrack = _trackRepository.Get(playlistDTO.TrackID);
                    if (tempTrack != null)
                    {
                        if (!tempPlaylist.TracksInPlaylist.Any(tp => tp.Track.Equals(tempTrack)))
                        {
                            TrackInPlaylist trackInPlaylist = _trackInPlaylistRepository.Insert(new TrackInPlaylist
                            {
                                TrackId = playlistDTO.TrackID,
                                Track = tempTrack,
                                PlaylistId = playlistDTO.PlaylistID,
                                Playlist = tempPlaylist
                            });
                            tempPlaylist.TracksInPlaylist.Add(trackInPlaylist);

                            return _playlistRepository.Update(tempPlaylist);
                        }
                    }
                }
            }

            return null;
        }

        public Playlist RemoveTrackFromPlaylist(string userId, AddTrackToPlaylistDTO playlistDTO)
        {
            if (userId != null) {

                var loggedInUser = _userRepository.Get(userId);

                var userPlaylists = loggedInUser?.MyPlaylists;

                Playlist? tempPlaylist = userPlaylists.Where(z => z.Id == playlistDTO.PlaylistID).FirstOrDefault();

                if (tempPlaylist != null)
                {
                    Track tempTrack = _trackRepository.Get(playlistDTO.TrackID);
                    if (tempTrack != null)
                    {
                        var trackToRemove = tempPlaylist.TracksInPlaylist.FirstOrDefault(tp => tp.Track.Equals(tempTrack));
                        if (trackToRemove != null)
                        {
                            tempPlaylist.TracksInPlaylist.Remove(trackToRemove);

                            return _playlistRepository.Update(tempPlaylist);
                        }
                    }
                }
            }

            return null;
        }

    }
    
}
