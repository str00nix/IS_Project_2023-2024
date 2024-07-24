using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain
{
    public class Track
    {
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public Artist? Artist { get; set; }
        public Album? Album { get; set; }
    }
}
