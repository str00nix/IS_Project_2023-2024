using Microsoft.EntityFrameworkCore;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Repository.Implementation
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Playlist> entities;

        public PlaylistRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Playlist>();
        }

        public List<Playlist> GetAllPlaylists()
        {
            return entities
                .Include(z => z.TracksInPlaylist)
                .Include(z => z.User)
                .ToList();
        }

        public Playlist GetDetailsForPlaylist(BaseEntity id)
        {
            return entities
                .Include(z => z.TracksInPlaylist)
                .Include(z => z.User)
                .Include("TrackInPlaylist.Track")
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;

        }
    }
}
