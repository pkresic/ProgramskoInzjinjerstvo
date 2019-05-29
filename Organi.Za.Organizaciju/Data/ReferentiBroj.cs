using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Organi.Za.Organizaciju.Data
{
    public class ReferentiBroj
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }

        [DisplayName("Trenutna Vrijednost")]
        public string TrenutnaVrijednost { get; set; }

        [DisplayName("Referenti Tip")]
        public int ReferentiTipId { get; set; }

        public TipReferentogBroja ReferentiTip { get; set; }
    }
}
