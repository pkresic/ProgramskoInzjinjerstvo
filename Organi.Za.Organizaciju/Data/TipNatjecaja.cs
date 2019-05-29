using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class TipNatjecaja
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(35)]
        public string Naziv { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Opis { get; set; }

    }
}