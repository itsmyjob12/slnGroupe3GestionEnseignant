using System.ComponentModel.DataAnnotations;

namespace Groupe3GestionEnseignant.Models.ENTITE
{
    public class Saisir
    {
        [Key]
        public DateTime Jour { get; set; }

        // NAVIGATION PROPERTY1
        public int IdCahierTexte { get; set; }
        public virtual CahierDeTexte? CahierDeTexte { get; set; }

        // NAVIGATION PROPERTY2
        public int IdEnseignant { get; set; }
        public virtual Enseignant? Enseignant { get; set; }
    }
}
