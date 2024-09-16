using AdminApplication.Models.Integration.BaseClass;
using AdminApplication.Models.Integration.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdminApplication.Models.Integration
{
    public class Album : BaseEntity
    {
        [Required]
        public string? AlbumName { get; set; }

        [Required]
        public string? AlbumDescription { get; set; }

        [Required]
        public string? AlbumCoverImage { get; set; }


        [Required]
        public GENRE Genre { get; set; }
        public virtual ICollection<Track>? Tracks { get; set; }
        public virtual ICollection<ArtistInAlbum>? Artists { get; set; }
    }
}
