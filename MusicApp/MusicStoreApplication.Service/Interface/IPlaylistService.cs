﻿using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
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
        public List<PlaylistDTO> GetPlaylistDTOs();
        public Playlist? GetPlaylistById(Guid id);
        public Playlist CreateNewPlaylist(Playlist playlist);
        public Playlist UpdatePlaylist(Playlist playlist);
        public Playlist DeletePlaylist(Guid id);
        public Playlist AddTrackToPlaylist(string userId, AddTrackToPlaylistDto playlistDTO);
        public Playlist RemoveTrackFromPlaylist(string userId, AddTrackToPlaylistDto playlistDTO);
    }
}
