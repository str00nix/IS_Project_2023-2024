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
    public class TrackRepository : ITrackRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<Track> entities;

        public TrackRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Track>();
        }

        public List<Track> GetAllTracks()
        {
            return entities
                .Include(z => z.TracksInPlaylist)
                .Include(z => z.Album)
                .ToList();
        }

        public Track GetDetailsForTrack(BaseEntity id)
        {
            return entities
                .Include(z => z.TracksInPlaylist)
                .Include(z => z.Album)
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }
    }
}
