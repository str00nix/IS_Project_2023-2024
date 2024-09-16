using Microsoft.AspNetCore.Identity;
using AdminApplication.Models.Integration;
using System.Collections.Generic;

namespace AdminApplication.Models.Integration.Identity
{
    public class AnyMusicUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Playlist>? MyPlaylists { get; set; }
    }
}