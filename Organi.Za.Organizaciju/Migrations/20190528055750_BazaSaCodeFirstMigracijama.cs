using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organi.Za.Organizaciju.Migrations
{
    public partial class BazaSaCodeFirstMigracijama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certifikati",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: true),
                    Opis = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifikati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategorijeEvenata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 35, nullable: true),
                    Opis = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijeEvenata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategorijeOpreme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijeOpreme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Mjesto = table.Column<string>(nullable: true),
                    Drzava = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    GeografskaSirina = table.Column<double>(nullable: false),
                    GeografskaDuzina = table.Column<double>(nullable: false),
                    LokalniNaziv = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    MjesecniTrosak = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skladista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: true),
                    LokalniNaziv = table.Column<string>(nullable: true),
                    Mjesto = table.Column<string>(maxLength: 50, nullable: true),
                    Grad = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoviNatjecaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 35, nullable: true),
                    Opis = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviNatjecaja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipReferentogBroja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipReferentogBroja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zanimanja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: true),
                    Opis = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanimanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<decimal>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    KategorijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usluge_KategorijeEvenata_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "KategorijeEvenata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertifikatiOsoba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertifikatId = table.Column<int>(nullable: false),
                    OsobaId = table.Column<int>(nullable: false),
                    DatumPolaganja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertifikatiOsoba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertifikatiOsoba_Certifikati_CertifikatId",
                        column: x => x.CertifikatId,
                        principalTable: "Certifikati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertifikatiOsoba_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Natjecaji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    TipId = table.Column<int>(nullable: false),
                    VrijediDo = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    VrijednostNatjecaja = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natjecaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Natjecaji_TipoviNatjecaja_TipId",
                        column: x => x.TipId,
                        principalTable: "TipoviNatjecaja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferentiBrojevi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    TrenutnaVrijednost = table.Column<string>(nullable: true),
                    ReferentiTipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferentiBrojevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferentiBrojevi_TipReferentogBroja_ReferentiTipId",
                        column: x => x.ReferentiTipId,
                        principalTable: "TipReferentogBroja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZanimanjaOsoba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZanimanjeId = table.Column<int>(nullable: false),
                    OsobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZanimanjaOsoba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZanimanjaOsoba_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZanimanjaOsoba_Zanimanja_ZanimanjeId",
                        column: x => x.ZanimanjeId,
                        principalTable: "Zanimanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PotrebnoZanimanje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UslugaId = table.Column<int>(nullable: false),
                    ZanimanjeId = table.Column<int>(nullable: false),
                    Broj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotrebnoZanimanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotrebnoZanimanje_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PotrebnoZanimanje_Zanimanja_ZanimanjeId",
                        column: x => x.ZanimanjeId,
                        principalTable: "Zanimanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PonudaZaNatjecaj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    UslugaId = table.Column<int>(nullable: false),
                    NatjecajId = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(nullable: false),
                    DodatnaPoruka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonudaZaNatjecaj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PonudaZaNatjecaj_Natjecaji_NatjecajId",
                        column: x => x.NatjecajId,
                        principalTable: "Natjecaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PonudaZaNatjecaj_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opreme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    InvertarniBroj = table.Column<double>(nullable: false),
                    NabavnaCijena = table.Column<decimal>(nullable: false),
                    TrenutnaCijena = table.Column<decimal>(nullable: false),
                    VrijemeAmortizacije = table.Column<DateTime>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false),
                    DostupnoOd = table.Column<DateTime>(nullable: false),
                    DostupnoDo = table.Column<DateTime>(nullable: false),
                    ReferentiBrojId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opreme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opreme_KategorijeOpreme_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "KategorijeOpreme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opreme_ReferentiBrojevi_ReferentiBrojId",
                        column: x => x.ReferentiBrojId,
                        principalTable: "ReferentiBrojevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opreme_Skladista_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PotrebnaOprema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UslugaId = table.Column<int>(nullable: false),
                    OpremaId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotrebnaOprema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotrebnaOprema_Opreme_OpremaId",
                        column: x => x.OpremaId,
                        principalTable: "Opreme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PotrebnaOprema_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SklopljeniPoslovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    PonudaId = table.Column<int>(nullable: true),
                    UslugaId = table.Column<int>(nullable: true),
                    VrijemeRadaOd = table.Column<DateTime>(nullable: false),
                    VrijemeRadaDo = table.Column<DateTime>(nullable: false),
                    LokacijaId = table.Column<int>(nullable: false),
                    DogovorenaCijena = table.Column<decimal>(nullable: false),
                    OpremaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SklopljeniPoslovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SklopljeniPoslovi_Lokacije_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SklopljeniPoslovi_Opreme_OpremaId",
                        column: x => x.OpremaId,
                        principalTable: "Opreme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SklopljeniPoslovi_PonudaZaNatjecaj_PonudaId",
                        column: x => x.PonudaId,
                        principalTable: "PonudaZaNatjecaj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SklopljeniPoslovi_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DodijeljenaOprema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpremaId = table.Column<int>(nullable: false),
                    BrojOpreme = table.Column<int>(nullable: false),
                    PosaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodijeljenaOprema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DodijeljenaOprema_Opreme_OpremaId",
                        column: x => x.OpremaId,
                        principalTable: "Opreme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DodijeljenaOprema_SklopljeniPoslovi_PosaoId",
                        column: x => x.PosaoId,
                        principalTable: "SklopljeniPoslovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DodijeljeneOsobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OsobaId = table.Column<int>(nullable: false),
                    BrojOsoba = table.Column<int>(nullable: false),
                    PosaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodijeljeneOsobe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DodijeljeneOsobe_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DodijeljeneOsobe_SklopljeniPoslovi_PosaoId",
                        column: x => x.PosaoId,
                        principalTable: "SklopljeniPoslovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CertifikatiOsoba_CertifikatId",
                table: "CertifikatiOsoba",
                column: "CertifikatId");

            migrationBuilder.CreateIndex(
                name: "IX_CertifikatiOsoba_OsobaId",
                table: "CertifikatiOsoba",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_DodijeljenaOprema_OpremaId",
                table: "DodijeljenaOprema",
                column: "OpremaId");

            migrationBuilder.CreateIndex(
                name: "IX_DodijeljenaOprema_PosaoId",
                table: "DodijeljenaOprema",
                column: "PosaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DodijeljeneOsobe_OsobaId",
                table: "DodijeljeneOsobe",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_DodijeljeneOsobe_PosaoId",
                table: "DodijeljeneOsobe",
                column: "PosaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Natjecaji_TipId",
                table: "Natjecaji",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_Opreme_KategorijaId",
                table: "Opreme",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Opreme_ReferentiBrojId",
                table: "Opreme",
                column: "ReferentiBrojId");

            migrationBuilder.CreateIndex(
                name: "IX_Opreme_SkladisteId",
                table: "Opreme",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_PonudaZaNatjecaj_NatjecajId",
                table: "PonudaZaNatjecaj",
                column: "NatjecajId");

            migrationBuilder.CreateIndex(
                name: "IX_PonudaZaNatjecaj_UslugaId",
                table: "PonudaZaNatjecaj",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_PotrebnaOprema_OpremaId",
                table: "PotrebnaOprema",
                column: "OpremaId");

            migrationBuilder.CreateIndex(
                name: "IX_PotrebnaOprema_UslugaId",
                table: "PotrebnaOprema",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_PotrebnoZanimanje_UslugaId",
                table: "PotrebnoZanimanje",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_PotrebnoZanimanje_ZanimanjeId",
                table: "PotrebnoZanimanje",
                column: "ZanimanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferentiBrojevi_ReferentiTipId",
                table: "ReferentiBrojevi",
                column: "ReferentiTipId");

            migrationBuilder.CreateIndex(
                name: "IX_SklopljeniPoslovi_LokacijaId",
                table: "SklopljeniPoslovi",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_SklopljeniPoslovi_OpremaId",
                table: "SklopljeniPoslovi",
                column: "OpremaId");

            migrationBuilder.CreateIndex(
                name: "IX_SklopljeniPoslovi_PonudaId",
                table: "SklopljeniPoslovi",
                column: "PonudaId");

            migrationBuilder.CreateIndex(
                name: "IX_SklopljeniPoslovi_UslugaId",
                table: "SklopljeniPoslovi",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_KategorijaId",
                table: "Usluge",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZanimanjaOsoba_OsobaId",
                table: "ZanimanjaOsoba",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZanimanjaOsoba_ZanimanjeId",
                table: "ZanimanjaOsoba",
                column: "ZanimanjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CertifikatiOsoba");

            migrationBuilder.DropTable(
                name: "DodijeljenaOprema");

            migrationBuilder.DropTable(
                name: "DodijeljeneOsobe");

            migrationBuilder.DropTable(
                name: "PotrebnaOprema");

            migrationBuilder.DropTable(
                name: "PotrebnoZanimanje");

            migrationBuilder.DropTable(
                name: "ZanimanjaOsoba");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Certifikati");

            migrationBuilder.DropTable(
                name: "SklopljeniPoslovi");

            migrationBuilder.DropTable(
                name: "Osobe");

            migrationBuilder.DropTable(
                name: "Zanimanja");

            migrationBuilder.DropTable(
                name: "Lokacije");

            migrationBuilder.DropTable(
                name: "Opreme");

            migrationBuilder.DropTable(
                name: "PonudaZaNatjecaj");

            migrationBuilder.DropTable(
                name: "KategorijeOpreme");

            migrationBuilder.DropTable(
                name: "ReferentiBrojevi");

            migrationBuilder.DropTable(
                name: "Skladista");

            migrationBuilder.DropTable(
                name: "Natjecaji");

            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "TipReferentogBroja");

            migrationBuilder.DropTable(
                name: "TipoviNatjecaja");

            migrationBuilder.DropTable(
                name: "KategorijeEvenata");
        }
    }
}
