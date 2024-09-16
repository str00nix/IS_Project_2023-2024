using AdminApplication.Models.Integration.BaseClass;

namespace AdminApplication.Models.Integration
{
    public class ArtistInTrack : BaseEntity
    {
        public Guid ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }

        public Guid TrackId { get; set; }
        public virtual Track? Track { get; set; }
    }
}
