using AdminApplication.Models.Integration.BaseClass;
using AdminApplication.Models.Integration.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdminApplication.Models.Integration
{
    public class Artist : BaseEntity
    {
        [Required]
        public string? ArtistName { get; set; }
        public string? ArtistDescription { get; set; }

        public virtual ICollection<ArtistInAlbum>? Albums { get; set; }
        public virtual ICollection<ArtistInTrack>? Tracks { get; set; }
    }
}
