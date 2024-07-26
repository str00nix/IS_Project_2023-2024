using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain
{
    public class Artist : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public ICollection<ArtistOfTrack>? Tracks { get; set; }
    }
}
