using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Repository.Interface
{
    public interface ITrackRepository : IRepository<Track>
    {
        List<Track> GetAllTracks();
    }
}
