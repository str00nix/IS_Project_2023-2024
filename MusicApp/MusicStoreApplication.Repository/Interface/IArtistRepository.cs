using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Repository.Interface
{
    public interface IArtistRepository : IRepository<Artist>
    {
        public bool DoesArtistExistByName(string name);
        public Artist GetArtistByName(string name);
    }
}
