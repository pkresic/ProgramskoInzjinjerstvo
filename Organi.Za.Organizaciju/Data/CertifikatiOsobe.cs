using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Organi.Za.Organizaciju.Data
{
    public class CertifikatiOsobe
    {
        public int Id { get; set; }

        [DisplayName("Certifikat")]
        public int CertifikatId { get; set; }

        public Certifikat Certifikat { get; set; }

        [DisplayName("Osoba")]
        public int OsobaId { get; set; }

        public Osoba Osoba { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Datum Polaganja")]
        public DateTime DatumPolaganja { get; set; }
    }
}