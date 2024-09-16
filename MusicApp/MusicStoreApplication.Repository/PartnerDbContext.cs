//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using AnyMusic.Domain.Domain;
//using AnyMusic.Domain.Identity;
//using System.Net.Sockets;

//namespace AnyMusic.Repository
//{
//    public class ApplicationDbContext : IdentityDbContext<AnyMusicUser>
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }
//        public virtual DbSet<Album> Albums { get; set; }
//        public virtual DbSet<Artist> Artists { get; set; }
//        public virtual DbSet<ArtistInAlbum> ArtistInAlbums { get; set; }
//        public virtual DbSet<ArtistInTrack> ArtistInTracks { get; set; }
//        public virtual DbSet<Playlist> Playlists { get; set; }
//        public virtual DbSet<Track> Tracks { get; set; }
//        public virtual DbSet<TrackInPlaylist> TrackInPlaylists { get; set; }

//    }
//}
