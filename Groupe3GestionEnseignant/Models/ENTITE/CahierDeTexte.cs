using System.ComponentModel.DataAnnotations;

namespace Groupe3GestionEnseignant.Models.ENTITE
{
    public class CahierDeTexte
    {
        [Key]
        public int IdCahierTexte { get; set; }
        public string Contenu{ get; set; }
        public DateTime Date { get; set; }
    }
}
