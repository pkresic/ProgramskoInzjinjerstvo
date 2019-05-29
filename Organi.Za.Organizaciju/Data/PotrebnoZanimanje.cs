using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Organi.Za.Organizaciju.Data
{
    public class PotrebnoZanimanje
    {
        [Key]
        public int Id { get; set; }

        public Zanimanje Zanimanje { get; set; }

        public Usluga Usluga { get; set; }

        [DisplayName("Odabrana usluga")]
        public int UslugaId { get; set; }

        [DisplayName("Odabrana usluga")]
        public int ZanimanjeId { get; set; }

        public int Broj { get; set; }
    }
}