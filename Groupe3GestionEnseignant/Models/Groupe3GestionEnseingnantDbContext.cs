using Groupe3GestionEnseignant.Models.ENTITE;
using Microsoft.EntityFrameworkCore;
namespace Groupe3GestionEnseignant.Models
{
    public class Groupe3GestionEnseingnantDbContext : DbContext
    {
        public Groupe3GestionEnseingnantDbContext(DbContextOptions<Groupe3GestionEnseingnantDbContext> options) : base(options)

        {

        }
        public DbSet<Absence> Absence { get; set; }
        public DbSet<CahierDeTexte> CahierDeTexte { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Cour> Cour { get; set; }
        public DbSet<Enseignant> Enseignant { get; set; }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<Saisir> Saisir { get; set; }   
    }
}


