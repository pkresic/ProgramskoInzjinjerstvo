﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Certifikat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(50);

                    b.Property<string>("Opis")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Certifikati");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.CertifikatiOsobe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CertifikatId");

                    b.Property<DateTime>("DatumPolaganja");

                    b.Property<int>("OsobaId");

                    b.HasKey("Id");

                    b.HasIndex("CertifikatId");

                    b.HasIndex("OsobaId");

                    b.ToTable("CertifikatiOsoba");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.DodijeljenaOprema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojOpreme");

                    b.Property<int>("OpremaId");

                    b.Property<int>("PosaoId");

                    b.HasKey("Id");

                    b.HasIndex("OpremaId");

                    b.HasIndex("PosaoId");

                    b.ToTable("DodijeljenaOprema");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.DodijeljeneOsobe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojOsoba");

                    b.Property<int>("OsobaId");

                    b.Property<int>("PosaoId");

                    b.HasKey("Id");

                    b.HasIndex("OsobaId");

                    b.HasIndex("PosaoId");

                    b.ToTable("DodijeljeneOsobe");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.KategorijaEventa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(35);

                    b.Property<string>("Opis")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("KategorijeEvenata");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.KategorijaOpreme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("KategorijeOpreme");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Lokacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drzava");

                    b.Property<double>("GeografskaDuzina");

                    b.Property<double>("GeografskaSirina");

                    b.Property<string>("LokalniNaziv");

                    b.Property<string>("Mjesto");

                    b.Property<string>("PostanskiBroj");

                    b.Property<string>("Ulica");

                    b.HasKey("Id");

                    b.ToTable("Lokacije");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Natjecaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<int>("TipId");

                    b.Property<DateTime>("VrijediDo");

                    b.Property<decimal>("VrijednostNatjecaja");

                    b.HasKey("Id");

                    b.HasIndex("TipId");

                    b.ToTable("Natjecaji");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Oprema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DostupnoDo");

                    b.Property<DateTime>("DostupnoOd");

                    b.Property<double>("InvertarniBroj");

                    b.Property<int?>("KategorijaId");

                    b.Property<int>("Kolicina");

                    b.Property<decimal>("NabavnaCijena");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<int>("ReferentiBrojId");

                    b.Property<int>("SkladisteId");

                    b.Property<decimal>("TrenutnaCijena");

                    b.Property<DateTime>("VrijemeAmortizacije");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.HasIndex("ReferentiBrojId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Opreme");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Osoba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Ime");

                    b.Property<decimal>("MjesecniTrosak");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.ToTable("Osobe");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.PonudaZaNatjecaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<string>("DodatnaPoruka");

                    b.Property<int>("NatjecajId");

                    b.Property<string>("Naziv");

                    b.Property<int>("UslugaId");

                    b.HasKey("Id");

                    b.HasIndex("NatjecajId");

                    b.HasIndex("UslugaId");

                    b.ToTable("PonudaZaNatjecaj");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.PotrebnaOprema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolicina");

                    b.Property<int>("OpremaId");

                    b.Property<int>("UslugaId");

                    b.HasKey("Id");

                    b.HasIndex("OpremaId");

                    b.HasIndex("UslugaId");

                    b.ToTable("PotrebnaOprema");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.PotrebnoZanimanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Broj");

                    b.Property<int>("UslugaId");

                    b.Property<int>("ZanimanjeId");

                    b.HasKey("Id");

                    b.HasIndex("UslugaId");

                    b.HasIndex("ZanimanjeId");

                    b.ToTable("PotrebnoZanimanje");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.ReferentiBroj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<int>("ReferentiTipId");

                    b.Property<string>("TrenutnaVrijednost");

                    b.HasKey("Id");

                    b.HasIndex("ReferentiTipId");

                    b.ToTable("ReferentiBrojevi");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Skladiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grad")
                        .HasMaxLength(50);

                    b.Property<string>("LokalniNaziv");

                    b.Property<string>("Mjesto")
                        .HasMaxLength(50);

                    b.Property<string>("Naziv")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Skladista");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.SklopljeniPosao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DogovorenaCijena");

                    b.Property<int>("LokacijaId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<int?>("OpremaId");

                    b.Property<int?>("PonudaId");

                    b.Property<int?>("UslugaId");

                    b.Property<DateTime>("VrijemeRadaDo");

                    b.Property<DateTime>("VrijemeRadaOd");

                    b.HasKey("Id");

                    b.HasIndex("LokacijaId");

                    b.HasIndex("OpremaId");

                    b.HasIndex("PonudaId");

                    b.HasIndex("UslugaId");

                    b.ToTable("SklopljeniPoslovi");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.TipNatjecaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(35);

                    b.Property<string>("Opis")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TipoviNatjecaja");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.TipReferentogBroja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("TipReferentogBroja");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Usluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<int>("KategorijaId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Usluge");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.ZanimanjaOsobe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OsobaId");

                    b.Property<int>("ZanimanjeId");

                    b.HasKey("Id");

                    b.HasIndex("OsobaId");

                    b.HasIndex("ZanimanjeId");

                    b.ToTable("ZanimanjaOsoba");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Zanimanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(50);

                    b.Property<string>("Opis")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Zanimanja");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.CertifikatiOsobe", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.Certifikat", "Certifikat")
                        .WithMany("Osobe")
                        .HasForeignKey("CertifikatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.Osoba", "Osoba")
                        .WithMany("Certifikats")
                        .HasForeignKey("OsobaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.DodijeljenaOprema", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.Oprema", "Oprema")
                        .WithMany()
                        .HasForeignKey("OpremaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.SklopljeniPosao", "Posao")
                        .WithMany("DodijeljenaOprema")
                        .HasForeignKey("PosaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.DodijeljeneOsobe", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.Osoba", "Osoba")
                        .WithMany()
                        .HasForeignKey("OsobaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.SklopljeniPosao", "Posao")
                        .WithMany("DodijeljeneOsobe")
                        .HasForeignKey("PosaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Natjecaj", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.TipNatjecaja", "Tip")
                        .WithMany()
                        .HasForeignKey("TipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Oprema", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.KategorijaOpreme", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId");

                    b.HasOne("Organi.Za.Organizaciju.Data.ReferentiBroj", "ReferentiBroj")
                        .WithMany()
                        .HasForeignKey("ReferentiBrojId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.PonudaZaNatjecaj", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.Natjecaj", "Natjecaj")
                        .WithMany("Ponude")
                        .HasForeignKey("NatjecajId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.Usluga", "Usluga")
                        .WithMany()
                        .HasForeignKey("UslugaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.PotrebnaOprema", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.Oprema", "Oprema")
                        .WithMany()
                        .HasForeignKey("OpremaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.Usluga", "Usluga")
                        .WithMany("PotrebnaOprema")
                        .HasForeignKey("UslugaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.PotrebnoZanimanje", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.Usluga", "Usluga")
                        .WithMany("PotrebnoZanimanje")
                        .HasForeignKey("UslugaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.Zanimanje", "Zanimanje")
                        .WithMany()
                        .HasForeignKey("ZanimanjeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.ReferentiBroj", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.TipReferentogBroja", "ReferentiTip")
                        .WithMany()
                        .HasForeignKey("ReferentiTipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.SklopljeniPosao", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.Lokacija", "Lokacija")
                        .WithMany()
                        .HasForeignKey("LokacijaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.Oprema")
                        .WithMany("Poslovi")
                        .HasForeignKey("OpremaId");

                    b.HasOne("Organi.Za.Organizaciju.Data.PonudaZaNatjecaj", "Ponuda")
                        .WithMany()
                        .HasForeignKey("PonudaId");

                    b.HasOne("Organi.Za.Organizaciju.Data.Usluga", "Usluga")
                        .WithMany()
                        .HasForeignKey("UslugaId");
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.Usluga", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.KategorijaEventa", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Organi.Za.Organizaciju.Data.ZanimanjaOsobe", b =>
                {
                    b.HasOne("Organi.Za.Organizaciju.Data.Osoba", "Osoba")
                        .WithMany("Zanimanja")
                        .HasForeignKey("OsobaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Organi.Za.Organizaciju.Data.Zanimanje", "Zanimanje")
                        .WithMany("Osobe")
                        .HasForeignKey("ZanimanjeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
