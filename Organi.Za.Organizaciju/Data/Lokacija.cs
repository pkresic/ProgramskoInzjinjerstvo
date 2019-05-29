namespace Organi.Za.Organizaciju.Data
{
    public class Lokacija
    {
        public int Id { get; set; }

        public string Mjesto { get; set; }

        public string Drzava { get; set; }

        public string PostanskiBroj { get; set; }

        public double GeografskaSirina { get; set; }

        public double GeografskaDuzina { get; set; }

        public string LokalniNaziv { get; set; }

        public string Ulica { get; set; }
    }
}