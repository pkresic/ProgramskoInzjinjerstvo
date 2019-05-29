using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class Osoba
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Datum Rođenja")]
        public DateTime DatumRodjenja { get; set; }

        [DisplayName("Mjesečni trošak")]
        public decimal MjesecniTrosak { get; set; }

        [DisplayName("Certifikati")]
        public ICollection<CertifikatiOsobe> Certifikats { get; set; }

        [DisplayName("Zanimanja")]
        public ICollection<ZanimanjaOsobe> Zanimanja { get; set; }

    }
}