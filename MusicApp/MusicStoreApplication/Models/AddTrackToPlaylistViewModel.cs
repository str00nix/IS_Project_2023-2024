using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;

namespace MusicStoreApplication.Web.Models
{
    public class AddTrackToPlaylistViewModel
    {

        public List<Playlist> Playlists;
        public Track Track;
        public AddTrackToPlaylistDto AddTrackToPlaylistDto;

        public AddTrackToPlaylistViewModel(
            List<Playlist> playlists, 
            Track track,
            AddTrackToPlaylistDto addTrackToPlaylistDto
        )
        {
            Playlists = playlists;
            Track = track;
            AddTrackToPlaylistDto = addTrackToPlaylistDto;
        }

        public AddTrackToPlaylistViewModel()
        {
            Playlists = new List<Playlist>();
            AddTrackToPlaylistDto = new AddTrackToPlaylistDto();
        }
    }
}
