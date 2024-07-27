﻿using Microsoft.EntityFrameworkCore;
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
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public Track Get(Guid? id)
        {
            return entities.First(s => s.Id == id);
        }

        public IEnumerable<Track> GetAll()
        {
            return entities.AsEnumerable();
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
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Track> InsertMany(List<Track> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            entities.AddRange(entities);
            context.SaveChanges();
            return entities;
        }

        public Track Update(Track entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
