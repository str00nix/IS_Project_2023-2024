using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Implementation
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public Track CreateNewTrack(Track track)
        {
            return _trackRepository.Insert(track);
        }

        public Track DeleteTrack(Guid id)
        {
            Track track = _trackRepository.GetDetailsForTrack(id);
            return _trackRepository.Delete(track);
        }

        public Track? GetTrackById(Guid id)
        {
            return _trackRepository.GetDetailsForTrack(id);
        }

        public List<Track> GetTracks()
        {
            return _trackRepository.GetAllTracks();
        }

        public Track UpdateTrack(Track track)
        {
            return _trackRepository.Update(track);
        }
    }
}
