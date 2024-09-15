using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Repository.Implementation
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Album> entities;

        public AlbumRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Album>();
        }

        public Album Delete(Album entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public Album Get(Guid? id)
        {
            var result = entities
                .Include(a => a.Tracks).ThenInclude(t => t.Artists).ThenInclude(at => at.Artist)
                .FirstOrDefaultAsync(z => z.Id == id).Result;

            return result;
        }

        public bool DoesAlbumExistByName(string name)
        {
            var result = entities
                .Any(a => a.Name == name);

            return result;
        }

        public IEnumerable<Album> GetAll()
        {
            var result = entities
                .Include(a => a.Tracks).ThenInclude(t => t.Artists).ThenInclude(at => at.Artist)
                .Include(a => a.Tracks).ThenInclude(t => t.Genres).ThenInclude(gt => gt.Genre)
                .AsEnumerable();

            return result;
        }

        public Album Insert(Album entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Album> InsertMany(List<Album> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            entities.AddRange(entities);
            context.SaveChanges();
            return entities;
        }

        public Album Update(Album entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
            return entity;
        }
        public Album GetAlbumByName(string name) {
            var result = entities
                .FirstOrDefault(a => a.Name == name);

            return result;
        }
    }
}
