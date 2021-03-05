using AfpaBrive;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAfpa
{
    public partial class CollaborateurAfpa :Personne
    {
        [Required(ErrorMessage = "Le matricule du collaborateur est requis.")]
        [StringLength(8, ErrorMessage = "La longeur du matricule doit être de 8 caractères.")]
        [RegularExpression(@"^[0-9]{3}[A-Z]{3}[0-9]{3}$", ErrorMessage = "Le matricule doit être de type 3 chiffres + 3 Caractères en Majuscule + 3 chiffres")]
        public string MatriculeCollaborateurAfpa { get; set; }

        public virtual ICollection<OffreFormation> OffreFormations { get; set; }

        public CollaborateurAfpa ()
        {
            OffreFormations = new HashSet<OffreFormation>();
        }

        #region methode
        public override bool Equals(object obj)
        {
            return obj is CollaborateurAfpa afpa &&
                   MatriculeCollaborateurAfpa == afpa.MatriculeCollaborateurAfpa;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MatriculeCollaborateurAfpa);
        }

        public override string ToString()
        {
            return base.ToString()+" "+this.MatriculeCollaborateurAfpa;
        }
        #endregion
    }
}
