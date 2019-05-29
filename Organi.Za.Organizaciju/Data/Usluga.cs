using System.Collections.Generic;
using System.ComponentModel;

namespace Organi.Za.Organizaciju.Data
{
    public class Usluga
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public decimal Cijena { get; set; }

        public string Opis { get; set; }

        public KategorijaEventa Kategorija { get; set; }

        [DisplayName("Kategorija")]
        public int KategorijaId { get; set; }

        public ICollection<PotrebnoZanimanje> PotrebnoZanimanje { get; set; }

        public ICollection<PotrebnaOprema> PotrebnaOprema { get; set; }
    }
}