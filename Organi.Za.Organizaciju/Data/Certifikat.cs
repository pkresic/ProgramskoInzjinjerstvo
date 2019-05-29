using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class Certifikat
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Naziv { get; set; }

        [MinLength(2)]
        [MaxLength(128)]
        public string Opis { get; set; }

        public ICollection<CertifikatiOsobe> Osobe { get; set; }
    }
}