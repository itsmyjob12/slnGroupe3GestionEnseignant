using System.ComponentModel.DataAnnotations;

namespace Groupe3GestionEnseignant.Models.ENTITE
{
    public class Classe
    {
        [Key]
        public int IdClasse { get; set; }
        public string Nom { get; set; }
        public string Designation { get; set; }


        // NAVIGATION PROPERTY1
        public int Matricule { get; set; }
        public virtual Etudiant? Etudiant { get; set; }

       

    }
}
