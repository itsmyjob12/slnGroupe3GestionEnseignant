using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Groupe3GestionEnseignant.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CahierDeTexte",
                columns: table => new
                {
                    IdCahierTexte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CahierDeTexte", x => x.IdCahierTexte);
                });

            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    IdEnseignant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "varchar(50)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotPasse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.IdEnseignant);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    Matricule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "varchar(50)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.Matricule);
                });

            migrationBuilder.CreateTable(
                name: "Saisir",
                columns: table => new
                {
                    Jour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCahierTexte = table.Column<int>(type: "int", nullable: false),
                    CahierDeTexteIdCahierTexte = table.Column<int>(type: "int", nullable: true),
                    IdEnseignant = table.Column<int>(type: "int", nullable: false),
                    EnseignantIdEnseignant = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saisir", x => x.Jour);
                    table.ForeignKey(
                        name: "FK_Saisir_CahierDeTexte_CahierDeTexteIdCahierTexte",
                        column: x => x.CahierDeTexteIdCahierTexte,
                        principalTable: "CahierDeTexte",
                        principalColumn: "IdCahierTexte");
                    table.ForeignKey(
                        name: "FK_Saisir_Enseignant_EnseignantIdEnseignant",
                        column: x => x.EnseignantIdEnseignant,
                        principalTable: "Enseignant",
                        principalColumn: "IdEnseignant");
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    IdAbscent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricule = table.Column<int>(type: "int", nullable: false),
                    EtudiantMatricule = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.IdAbscent);
                    table.ForeignKey(
                        name: "FK_Absence_Etudiant_EtudiantMatricule",
                        column: x => x.EtudiantMatricule,
                        principalTable: "Etudiant",
                        principalColumn: "Matricule");
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    IdClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricule = table.Column<int>(type: "int", nullable: false),
                    EtudiantMatricule = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.IdClasse);
                    table.ForeignKey(
                        name: "FK_Classe_Etudiant_EtudiantMatricule",
                        column: x => x.EtudiantMatricule,
                        principalTable: "Etudiant",
                        principalColumn: "Matricule");
                });

            migrationBuilder.CreateTable(
                name: "Cour",
                columns: table => new
                {
                    IdCour = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdClasse = table.Column<int>(type: "int", nullable: false),
                    ClasseIdClasse = table.Column<int>(type: "int", nullable: true),
                    IdEnseignant = table.Column<int>(type: "int", nullable: false),
                    EnseignantIdEnseignant = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cour", x => x.IdCour);
                    table.ForeignKey(
                        name: "FK_Cour_Classe_ClasseIdClasse",
                        column: x => x.ClasseIdClasse,
                        principalTable: "Classe",
                        principalColumn: "IdClasse");
                    table.ForeignKey(
                        name: "FK_Cour_Enseignant_EnseignantIdEnseignant",
                        column: x => x.EnseignantIdEnseignant,
                        principalTable: "Enseignant",
                        principalColumn: "IdEnseignant");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_EtudiantMatricule",
                table: "Absence",
                column: "EtudiantMatricule");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_EtudiantMatricule",
                table: "Classe",
                column: "EtudiantMatricule");

            migrationBuilder.CreateIndex(
                name: "IX_Cour_ClasseIdClasse",
                table: "Cour",
                column: "ClasseIdClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Cour_EnseignantIdEnseignant",
                table: "Cour",
                column: "EnseignantIdEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_Saisir_CahierDeTexteIdCahierTexte",
                table: "Saisir",
                column: "CahierDeTexteIdCahierTexte");

            migrationBuilder.CreateIndex(
                name: "IX_Saisir_EnseignantIdEnseignant",
                table: "Saisir",
                column: "EnseignantIdEnseignant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "Cour");

            migrationBuilder.DropTable(
                name: "Saisir");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "CahierDeTexte");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Etudiant");
        }
    }
}
