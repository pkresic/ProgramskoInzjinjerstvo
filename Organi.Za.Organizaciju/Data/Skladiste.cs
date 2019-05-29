using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class Skladiste
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Naziv { get; set; }

        [DisplayName("Lokalni naziv")] public string LokalniNaziv { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Mjesto { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Grad { get; set; }
    }
}