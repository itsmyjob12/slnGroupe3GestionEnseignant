using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Groupe3GestionEnseignant.Models.ENTITE
{
    public class Etudiant
    {
        [Key]
        public int Matricule { get; set; }
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nom d'etudiant")]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
    }
}
