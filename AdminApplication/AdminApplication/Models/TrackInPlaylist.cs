using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.Models
{
    public class TrackInPlaylist : BaseEntity
    {
        public Guid TrackId { get; set; }
        public Track? Track { get; set; }
        public Guid PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
    }
}
