using Microsoft.AspNetCore.Identity;
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

        public Playlist Get(Guid? id)
        {
            var result = entities
                .Include(p => p.TracksInPlaylist).ThenInclude(tp => tp.Track)
                .Include(p => p.User)
                .SingleOrDefaultAsync(z => z.Id == id).Result;

            return result;
        }
        
        public IEnumerable<Playlist> GetAll()
        {
            return entities
                .Include(p => p.User)
                .Include(p => p.TracksInPlaylist).ThenInclude(tp => tp.Track).ThenInclude(t => t.Album)
                .Include(p => p.TracksInPlaylist).ThenInclude(tp => tp.Track).ThenInclude(t => t.Artists).ThenInclude(at => at.Artist)
                .Include(p => p.TracksInPlaylist).ThenInclude(tp => tp.Track).ThenInclude(t => t.Genres).ThenInclude(gt => gt.Genre);
        }

        public Playlist Insert(Playlist entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Playlist Update(Playlist entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
            return entity;
        }

        public Playlist Delete(Playlist entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Playlist> InsertMany(List<Playlist> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            entities.AddRange(entities);
            context.SaveChanges();
            return entities;
        }
    }
}
