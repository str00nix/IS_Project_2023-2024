using AdminApplication.Models.Integration.BaseClass;

namespace AdminApplication.Models.Integration
{
    public class TrackInPlaylist : BaseEntity
    {
        public Guid TrackId { get; set; }
        public virtual Track? Track { get; set; }

        public Guid PlaylistId { get; set; }
        public virtual Playlist? Playlist { get; set; }
    }
}
