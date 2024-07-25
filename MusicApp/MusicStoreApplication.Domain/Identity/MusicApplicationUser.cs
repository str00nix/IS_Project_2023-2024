using Microsoft.AspNetCore.Identity;
using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Identity
{
    public class MusicApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        //public ShoppingCart? UserCart { get; set; }
        public virtual ICollection<Playlist>? MyPlaylist { get; set; }
    }
}
