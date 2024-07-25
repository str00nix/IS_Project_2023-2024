using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Interface
{
    public interface ITrackService
    {
        public List<Track> GetTracks();
        public Track? GetTrackById(Guid id);
        public Track CreateNewTrack(Track track);
        public Track UpdateTrack(Track track);
        public Track DeleteTrack(Guid id);
    }
}
