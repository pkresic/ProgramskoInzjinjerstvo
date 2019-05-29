using System.Collections.Generic;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.ViewModels
{
    public class PosloviViewModel
    {
        public IEnumerable<SklopljeniPosao> Poslovi { get; set; }

        public IEnumerable<Osoba> DodijeljeneOsobe { get; set; }

        public IEnumerable<Oprema> DodideljenaOprema { get; set; }

    }
}