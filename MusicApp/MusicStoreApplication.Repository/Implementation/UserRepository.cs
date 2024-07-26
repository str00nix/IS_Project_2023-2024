using Microsoft.EntityFrameworkCore;
using MusicStoreApplication.Domain.Identity;
using MusicStoreApplication.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<MusicApplicationUser> entities;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<MusicApplicationUser>();
        }

        public void Delete(MusicApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public MusicApplicationUser Get(string id)
        {
            return entities
                 .SingleOrDefaultAsync(z => z.Id == id).Result;
        }

        public IEnumerable<MusicApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(MusicApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(MusicApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
