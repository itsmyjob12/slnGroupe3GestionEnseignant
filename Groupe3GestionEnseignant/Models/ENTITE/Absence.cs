using System.ComponentModel.DataAnnotations;

namespace Groupe3GestionEnseignant.Models.ENTITE
{
    public class Absence
    {
        [Key]
        public int IdAbscent { get; set; }
        public DateTime Jour { get; set; }
        public string Motif { get; set; }


        public int Matricule { get; set; }
        public virtual Etudiant? Etudiant { get; set; }

    }
}
