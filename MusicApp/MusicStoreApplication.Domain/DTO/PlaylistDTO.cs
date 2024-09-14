using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.DTO
{
    public class PlaylistDTO
    {
        public string PlaylistName { get; set; }
        public Dictionary<string, string> User { get; set; }
        public List<Dictionary<string, string>> Tracks { get; set; }
    }
}
