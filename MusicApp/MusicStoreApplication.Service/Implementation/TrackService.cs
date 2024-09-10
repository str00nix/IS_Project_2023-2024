using Microsoft.AspNetCore.Http;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Repository.Implementation;
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
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IRepository<ArtistOfTrack> _artistOfTrackRepository;

        public TrackService(ITrackRepository trackRepository, IAlbumRepository albumRepository, IArtistRepository artistRepository, IRepository<ArtistOfTrack> artistOfTrackRepository)
        {
            _trackRepository = trackRepository;
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _artistOfTrackRepository = artistOfTrackRepository;
        }

        public Track CreateNewTrack(Track track)
        {
            return _trackRepository.Insert(track);
        }

        public Track DeleteTrack(Guid id)
        {
            Track track = _trackRepository.Get(id);
            return _trackRepository.Delete(track);
        }

        public Track? GetTrackById(Guid id)
        {
            return _trackRepository.Get(id);
        }

        public List<Track> GetTracks()
        {
            return _trackRepository.GetAll().ToList();
        }

        public Track UpdateTrack(Track track)
        {
            return _trackRepository.Update(track);
        }


        public async Task<bool> ImportTracks(IFormFile formFile)
        {
            Console.WriteLine("Service method for track import called");

            using var reader = new StreamReader(formFile.OpenReadStream());

            var content = reader.ReadLine();
            while (reader.EndOfStream == false)
            {
                content = reader.ReadLine();
                //try
                //{
                var parts = content.Split(',').ToList();

                if (parts.All(x => x.Length > 0))
                {
                    //artists,album_name,track_name,duration_ms,track_genre
                    List<string> artistNames = new List<string>(parts[0].Split(';'));
                    string albumName = parts[1];
                    Album tempAlbum;
                    if (!_albumRepository.DoesAlbumExistByName(albumName))
                    {
                    tempAlbum = new Album()
                    {
                            Name = albumName
                    };
                    tempAlbum = _albumRepository.Insert(tempAlbum);
                    }
                    else 
                    {
                        tempAlbum = _albumRepository.GetAlbumByName(albumName);
                    }

                    string trackName = parts[2];
                    double duration_ms = double.Parse(parts[3]);
                    string genre = parts[4];
                    Track tempTrack = new Track()
                    {
                        Name = trackName,
                        Genre = genre,
                        Album = tempAlbum,
                        DurationInMilliseconds = duration_ms
                    };

                    artistNames.ForEach(name =>
                    {
                        if (name.Length > 0) 
                        {
                            Artist tempArtist;
                            if (!_artistRepository.DoesArtistExistByName(name))
                            {
                                tempArtist = new Artist()
                                {
                                    Name = name
                                };
                                tempArtist = _artistRepository.Insert(tempArtist);
                            }
                            else 
                            {
                                tempArtist = _artistRepository.GetArtistByName(name);
                            }

                            ArtistOfTrack artistOfTrack = new ArtistOfTrack()
                            {
                                Artist = tempArtist,
                                ArtistId = tempArtist.Id,
                                Track = tempTrack,
                                TrackId = tempTrack.Id
                            };

                            artistOfTrack = _artistOfTrackRepository.Insert(artistOfTrack);

                            tempTrack.Artists.Add(artistOfTrack);
                        }
                    });

                    //CreateNewTrack(tempTrack);
                    tempTrack = _trackRepository.Insert(tempTrack);
                }
            }

            return true;
        }

    }
}
