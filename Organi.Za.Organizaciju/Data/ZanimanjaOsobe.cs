using System.ComponentModel;

namespace Organi.Za.Organizaciju.Data
{
    public class ZanimanjaOsobe
    {

        public int Id { get; set; }

        [DisplayName("Zanimanje")]
        public int ZanimanjeId { get; set; }

        public Zanimanje Zanimanje { get; set; }

        [DisplayName("Osoba")]
        public int OsobaId { get; set; }

        public Osoba Osoba { get; set; }
    }
}