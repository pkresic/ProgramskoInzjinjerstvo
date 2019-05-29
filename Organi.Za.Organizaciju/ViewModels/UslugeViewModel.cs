using System.Collections.Generic;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.ViewModels
{
    public class UslugeViewModel
    {
        public IEnumerable<Usluga> Usluge { get; set; }

        public IEnumerable<Oprema> PotrebnaOprema { get; set; }

        public IEnumerable<Zanimanje> PotrebnaZanimanja { get; set; }
    }
}