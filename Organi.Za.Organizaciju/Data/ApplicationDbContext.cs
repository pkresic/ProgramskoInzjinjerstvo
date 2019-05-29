using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<KategorijaEventa> KategorijeEvenata { get; set; }

        public DbSet<KategorijaOpreme> KategorijeOpreme { get; set; }

        public DbSet<Lokacija> Lokacije { get; set; }

        public DbSet<Natjecaj> Natjecaji { get; set; }

        public DbSet<Oprema> Opreme { get; set; }

        public DbSet<Skladiste> Skladista { get; set; }

        public DbSet<TipReferentogBroja> TipReferentogBroja { get; set; }

        public DbSet<ReferentiBroj> ReferentiBrojevi { get; set; }

        public DbSet<Osoba> Osobe { get; set; }

        public DbSet<CertifikatiOsobe> CertifikatiOsoba { get; set; }

        public DbSet<ZanimanjaOsobe> ZanimanjaOsoba { get; set; }

        public DbSet<SklopljeniPosao> SklopljeniPoslovi { get; set; }

        public DbSet<TipNatjecaja> TipoviNatjecaja { get; set; }

        public DbSet<PonudaZaNatjecaj> PonudaZaNatjecaj { get; set; }

        public DbSet<DodijeljeneOsobe> DodijeljeneOsobe { get; set; }

        public DbSet<Usluga> Usluge { get; set; }

        public DbSet<Zanimanje> Zanimanja { get; set; }

        public DbSet<Certifikat> Certifikati { get; set; }

        public DbSet<PotrebnaOprema> PotrebnaOprema { get; set; }

        public DbSet<PotrebnoZanimanje> PotrebnoZanimanje { get; set; }


        public DbSet<DodijeljenaOprema> DodijeljenaOprema { get; set; }
       
    }
}