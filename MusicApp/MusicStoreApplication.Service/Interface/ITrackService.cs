﻿using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Service.Interface
{
    public interface ITrackService
    {
        public List<Track> GetTracks(string? searchString = null, string[]? artistSelect = null, int page = 1, int pageSize = 15, SortOrder sortOrder = SortOrder.Ascending, string? sortBy = null);
        public Track? GetTrackById(Guid id);
        public Track CreateNewTrack(Track track);
        public Track UpdateTrack(Track track);
        public Track DeleteTrack(Guid id);
        public Task<bool> ImportTracks(IFormFile formFile);
        public Track CreateNewTrackFromDTO(TrackDto trackDto);
    }
}
