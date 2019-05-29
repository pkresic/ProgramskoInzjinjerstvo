using System.Collections.Generic;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.ViewModels
{
    public class NatjecajiViewModel
    {
        public IEnumerable<Natjecaj> Natjecaji { get; set; }

        public IEnumerable<PonudaZaNatjecaj> Ponude { get; set; }
    }
}