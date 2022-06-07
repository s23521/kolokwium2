using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class Musician_Track
    {
        public int Idtrack { get; set; }
        public int IdMusician { get; set; }
        public virtual Track Track {get; set;}
        public virtual Musician Musician {get; set;}
    }
}