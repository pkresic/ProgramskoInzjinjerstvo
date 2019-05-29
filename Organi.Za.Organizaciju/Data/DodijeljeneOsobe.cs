using System.ComponentModel;

namespace Organi.Za.Organizaciju.Data
{
    public class DodijeljeneOsobe
    {
        public int Id { get; set; }

        public Osoba Osoba { get; set; }

        [DisplayName("Osoba")]
        public int OsobaId { get; set; }

        [DisplayName("Broj osoba")]
        public int BrojOsoba { get; set; }

        public int PosaoId { get; set; }

        public SklopljeniPosao Posao { get; set; }
    }
}