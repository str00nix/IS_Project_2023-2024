using AdminApplication.Models.Integration.BaseClass;
using AdminApplication.Models.Integration.Identity;
using System.ComponentModel.DataAnnotations;


namespace AdminApplication.Models.Integration
{
    public class Playlist : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public virtual AnyMusicUser? User { get; set; }
        public virtual ICollection<TrackInPlaylist>? TracksInPlaylists { get; set; }
    }
}
