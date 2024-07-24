using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain
{
    public class Artist : BaseEntity
    {
        public string? Name { get; set; }
        //public List<Track>? Tracks { get; set; }
    }
}
