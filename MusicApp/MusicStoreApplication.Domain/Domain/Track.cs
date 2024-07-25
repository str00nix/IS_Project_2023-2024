using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain
{
    public class Track : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public ICollection<Artist>? Artists { get; set; }
        [Required]
        public Album? Album { get; set; }
    }
}
