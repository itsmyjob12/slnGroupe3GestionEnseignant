using System.ComponentModel.DataAnnotations;

namespace Groupe3GestionEnseignant.Models.ENTITE
{
    public class Cour
    {
        [Key]
        public int IdCour { get; set; }
        public string Nom { get; set; }
        public string Horaire { get; set; }


        // NAVIGATION PROPERTY1
        public int IdClasse { get; set; }
        public virtual Classe? Classe{ get; set; }

        // NAVIGATION PROPERTY2
        public int IdEnseignant { get; set; }
        public virtual Enseignant? Enseignant { get; set; }
    }
}
