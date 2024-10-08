﻿using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Repository.Interface
{
    public interface IAlbumRepository : IRepository<Album>
    {
        //public List<Album> InsertMany(List<Album> entities);
        public bool DoesAlbumExistByName(string name);
        public Album GetAlbumByName(string name);
    }
}
