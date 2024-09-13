using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
using MusicStoreApplication.Repository.Implementation;
using MusicStoreApplication.Repository.Interface;
using MusicStoreApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Track CreateNewTrackFromDTO(TrackDto trackDto)
        {
            var tempTrack = new Track() {
                Name = trackDto.Name,
                Genre = trackDto.Genre,
                Album = _albumRepository.Get(trackDto.AlbumId),
            };
            
            tempTrack = _trackRepository.Insert(tempTrack);

            tempTrack.Artists = new List<ArtistOfTrack>();
            foreach (Guid? artistId in trackDto.ArtistIds)
            {
                var trackArtist = new ArtistOfTrack();
                trackArtist.ArtistId = (Guid)artistId;
                trackArtist.Track = tempTrack;
            }
            _trackRepository.Update(tempTrack);

            return _trackRepository.Insert(tempTrack);
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

        public List<Track> GetTracks(string? searchString = null, string[]? artistSelect = null, int page = 1, int pageSize = 15, SortOrder sortOrder = SortOrder.Ascending, string? sortBy = null)
        {
            var tracks = _trackRepository.GetAll();
            if (searchString != null)
            {
                tracks = tracks.Where(t => t.Name.ToLower().Contains(searchString.ToLower()));
            }

            if (artistSelect != null && artistSelect.Length != 0)
            {
                tracks = tracks.Where(t => t.Artists.Where(at => artistSelect.Contains(at.Artist.Name)).Any());
            }

            return tracks.ToList();
        }

        public Track UpdateTrack(Track track)
        {
            return _trackRepository.Update(track);
        }


        public async Task<bool> ImportTracks(IFormFile formFile)
        {
            Console.WriteLine("Service method for track import called");

            using var reader = new StreamReader(formFile.OpenReadStream());

            var content = reader.ReadLine(); //dummy for CSV headers
            while (reader.EndOfStream == false)
            {
                content = reader.ReadLine();

                content = Regex.Replace(content, @",(?!(([^""]*""){2})*[^""]*$)", "，").Replace("\"\"", "\"");

                try
                {
                    var parts = content.Split(',').ToList();

                    if (parts.All(x => x.Length > 0))
                    {

                        //artists,album_name,track_name,duration_ms,track_genre

                        List<string> artistNames = new List<string>(parts[0].Split(';'));

                        string albumName = parts[1].Replace("，", ", ");


                    Album tempAlbum;
                    if (!_albumRepository.DoesAlbumExistByName(albumName))
                    {
                        tempAlbum = new Album()
                        {
                            Name = albumName
                        };
                        tempAlbum = _albumRepository.Insert(tempAlbum);
                    }
                    else {
                        tempAlbum = _albumRepository.GetAlbumByName(albumName);
                    }

                        string trackName = parts[2].Replace("，", ", ");

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
                            if (name.Length > 0) {

                                Artist tempArtist;

                                if (!_artistRepository.DoesArtistExistByName(name))
                                {
                                    tempArtist = new Artist()
                                    {
                                        Name = name
                                    };
                                    tempArtist = _artistRepository.Insert(tempArtist);
                                }
                                else {
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
                        tempTrack = _trackRepository.Update(tempTrack);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(content);
                    Console.WriteLine(ex.Message);
                    break;
                }
        }

            return true;
        }

    }
}
