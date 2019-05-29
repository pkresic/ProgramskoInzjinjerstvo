using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class KategorijaEventa
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(35)]
        public string Naziv { get; set; }

        [MinLength(2)]
        [MaxLength(128)]
        public string Opis { get; set; }
    }
}