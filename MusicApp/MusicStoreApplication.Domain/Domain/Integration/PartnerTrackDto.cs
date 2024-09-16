using MusicStoreApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain.Integration
{
    public class PartnerTrackDto
    {
        public string Name { get; set; }
        public List<string>? ArtistNames { get; set; }
        public string? AlbumName { get; set; }
        public double DurationInSeconds { get; set; }
        public double Rating { get; set; }
    }
}
