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
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Artist> entities;


        public ArtistRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Artist>();
        }
        public Artist Delete(Artist entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public Artist Get(Guid? id)
        {
            var result = entities
                .Include(a => a.Tracks).ThenInclude(t => t.Track)
                .Include(a => a.Tracks).ThenInclude(t => t.Track).ThenInclude(t => t.Album)
                .Include(a => a.Tracks).ThenInclude(t => t.Track).ThenInclude(t => t.Genres).ThenInclude(gt => gt.Genre)
                .FirstOrDefaultAsync(z => z.Id == id).Result;

            return result;
        }

        public bool DoesArtistExistByName(string name)
        {
            var result = entities
                .Any(a => a.Name == name);

            return result;
        }

        public IEnumerable<Artist> GetAll()
        {
            var result = entities.AsEnumerable();

            return result;
        }

        public Artist Insert(Artist entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Artist> InsertMany(List<Artist> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            entities.AddRange(entities);
            context.SaveChanges();
            return entities;
        }

        public Artist Update(Artist entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
            return entity;
        }
        public Artist GetArtistByName(string name) {
            var result = entities
                .FirstOrDefault(a => a.Name == name);

            return result;
        }
    }
}
