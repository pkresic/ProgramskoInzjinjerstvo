using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Organi.Za.Organizaciju.Data
{
    public class Oprema
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }

        [DisplayName("Invertarni Broj")]
        public double InvertarniBroj { get; set; }

        [DisplayName("Nabavna Cijena")]
        public decimal NabavnaCijena { get; set; }

        [DisplayName("Trenutna Cijena")]
        public decimal TrenutnaCijena { get; set; }

        [DisplayName("Vrijeme Amortizacije")]
        public DateTime VrijemeAmortizacije { get; set; }

        public KategorijaOpreme Kategorija { get; set; }

        public int Kolicina { get; set; }

        public Skladiste Skladiste { get; set; }

        [DisplayName("Skladište")]
        public int SkladisteId { get; set; }

        public ReferentiBroj ReferentiBroj { get; set; }

        [DisplayName("Dostupno Od")]
        public DateTime DostupnoOd { get; set; }

        [DisplayName("Dostupno Do")]
        public DateTime DostupnoDo { get; set; }

        [DisplayName("Referenti Broj")]
        public int ReferentiBrojId { get; set; }

        public ICollection<SklopljeniPosao> Poslovi { get; set; }
    }
}