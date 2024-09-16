using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminApplication.Models.Integration.BaseClass;

namespace AdminApplication.Models.Integration
{
    public class Track : BaseEntity
    {
        [Required]
        public string? TrackName { get; set; }
        public Guid? AlbumId { get; set; }
        public virtual Album? Album { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Range(0, 5)]
        public double Rating { get; set; }
        public virtual ICollection<ArtistInTrack>? Artists { get; set; }
        public virtual ICollection<TrackInPlaylist>? TracksInPlaylists { get; set; }
    }

}
