using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<Musician_Track> MusicianTracks {get; set;}
    }
}