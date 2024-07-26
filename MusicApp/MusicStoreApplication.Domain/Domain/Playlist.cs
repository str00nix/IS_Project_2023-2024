using MusicStoreApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain
{
    public class Playlist : BaseEntity
    {
        //public string? UserId { get; set; }
        //[Required]
        public MusicApplicationUser? User { get; set; }
        public ICollection<TrackInPlaylist>? TracksInPlaylist { get; set; }
    }
}
