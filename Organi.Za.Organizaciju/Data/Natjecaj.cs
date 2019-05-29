using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class Natjecaj
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        [DisplayName("Tip Natječaja")]
        public int TipId { get; set; }

        public TipNatjecaja Tip { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Vrijedi do")]
        public DateTime VrijediDo { get; set; }

        public string Opis { get; set; }

        [DisplayName("Vrijednost Natjecaja")]
        public decimal VrijednostNatjecaja { get; set; }

        public ICollection<PonudaZaNatjecaj> Ponude { get; set; }
    }
}