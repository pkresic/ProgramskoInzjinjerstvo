using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class DodijeljenaOprema
    {
        public int Id { get; set; }

        public Oprema Oprema { get; set; }

        [DisplayName("Oprema")]
        public int OpremaId { get; set; }

        [DisplayName("Broj opreme")]
        public int BrojOpreme { get; set; }

        [DisplayName("Posao")]
        public int PosaoId { get; set; }

        public SklopljeniPosao Posao { get; set; }
    }
}