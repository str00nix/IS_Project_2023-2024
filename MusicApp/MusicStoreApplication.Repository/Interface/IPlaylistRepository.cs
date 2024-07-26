using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Repository.Interface
{
    public interface IPlaylistRepository
    {
        List<Playlist> GetAllPlaylists();
        Playlist GetDetailsForPlaylist(Guid id);
    }
}
