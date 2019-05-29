using System.ComponentModel;

namespace Organi.Za.Organizaciju.Data
{
    public class PonudaZaNatjecaj
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        [DisplayName("Usluga")] public int UslugaId { get; set; }

        public Usluga Usluga { get; set; }

        public Natjecaj Natjecaj { get; set; }

        [DisplayName("Natječaj")] public int NatjecajId { get; set; }

        public decimal Cijena { get; set; }

        [DisplayName("Dodatna Poruka")] public string DodatnaPoruka { get; set; }
    }
}