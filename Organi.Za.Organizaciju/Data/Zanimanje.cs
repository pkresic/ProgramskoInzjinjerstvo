using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class Zanimanje
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Naziv { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Opis { get; set; }

        public ICollection<ZanimanjaOsobe> Osobe { get; set; }
    }
}