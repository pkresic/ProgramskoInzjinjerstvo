namespace Organi.Za.Organizaciju.Data
{
    public class PotrebnaOprema
    {
        public int Id { get; set; }

        public Usluga Usluga { get; set; }

        public int UslugaId { get; set; }

        public Oprema Oprema { get; set; }

        public int OpremaId { get; set; }

        public int Kolicina { get; set; }
    }
}