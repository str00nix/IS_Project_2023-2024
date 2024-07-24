using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain
{
    public class Track : BaseEntity
    {
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public List<Artist>? Artists { get; set; }
        public Album? Album { get; set; }
    }
}
