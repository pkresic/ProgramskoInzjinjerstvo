using System.Collections.Generic;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.ViewModels
{
    public class OsobaViewModel
    {
        public IEnumerable<Osoba> Osobe { get; set; }

        public IEnumerable<Certifikat> Certifikati { get; set; }

        public IEnumerable<Zanimanje> Zanimanja { get; set; }
    }
}