﻿using MusicStoreApplication.Domain.Domain;
using MusicStoreApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.DTO
{
    public class AddTrackToPlaylistDto
    {
        public Guid PlaylistID { get; set; }
        public Guid TrackID { get; set; }
    }
}
