using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Organi.Za.Organizaciju.Data
{
    public class SklopljeniPosao
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }

        public PonudaZaNatjecaj Ponuda { get; set; }

        [DisplayName("Ponuda")]
        public int? PonudaId { get; set; }

        public Usluga Usluga { get; set; }

        [DisplayName("Usluga")]
        public int? UslugaId { get; set; }

        public DateTime VrijemeRadaOd { get; set; }

        public DateTime VrijemeRadaDo { get; set; }

        public Lokacija Lokacija { get; set; }

        [DisplayName("Lokacija")]
        public int LokacijaId { get; set; }

        public decimal DogovorenaCijena { get; set; }

        public ICollection<DodijeljeneOsobe> DodijeljeneOsobe { get; set; }

        public ICollection<DodijeljenaOprema> DodijeljenaOprema { get; set; }
    }
}