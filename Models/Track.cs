using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public double Duration { get; set; }
        public int IdMusicAlbum { get; set; }
        public virtual ICollection<Musician_Track> MusicianTracks {get; set;}
        public virtual Album Album {get; set;}
    }
}