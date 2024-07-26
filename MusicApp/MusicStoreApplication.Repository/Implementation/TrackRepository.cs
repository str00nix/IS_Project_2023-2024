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

        public Track Delete(Track entity)
        {
            throw new NotImplementedException();
        }

        public Track Get(Guid? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Track> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Track> GetAllTracks()
        {
            return entities
                .Include(z => z.Album)
                .Include(z => z.Artists)
                .ToList();
        }

        public Track GetDetailsForTrack(Guid id)
        {
            return entities
                .Include(z => z.Album)
                .Include(z => z.Artists)
                .SingleOrDefaultAsync(z => z.Id == id).Result;
        }

        public Track Insert(Track entity)
        {
            throw new NotImplementedException();
        }

        public List<Track> InsertMany(List<Track> entities)
        {
            throw new NotImplementedException();
        }

        public Track Update(Track entity)
        {
            throw new NotImplementedException();
        }
    }
}
