using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AfpaBrive;

namespace ModelAfpa
{
    //[MetadataType(typeof(StagiaireMetaData))]
    public partial class Stagiaire : Personne
    {
        public Stagiaire()
        {
            StagiaireOffreFormations = new HashSet<StagiaireOffreFormation>();
            PeeIdStagiaireNavigations = new HashSet<Pee>();
        }

        [Required(ErrorMessage = "Le matricule du stagiaire est requis.")]
        [StringLength(8, ErrorMessage = "La longeur du matricule est de 8 chiffres.")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Le matricule doit être composé de 8 chiffres.")]
        public string MatriculeStagiaire { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateNaissanceStagiaire { get; set; }

        public virtual ICollection<StagiaireOffreFormation> StagiaireOffreFormations { get; set; }
        public virtual ICollection<Pee> PeeIdStagiaireNavigations { get; set; }

        #region methode de subtitution
        public override bool Equals(object obj)
        {
            if (!(obj is Stagiaire stagiaire))
            {
                return false;
            }
            return (this.GetHashCode() == stagiaire.GetHashCode());
        }

        public override int GetHashCode()
        {
            return this.MatriculeStagiaire == string.Empty ? 0 : this.MatriculeStagiaire.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.MatriculeStagiaire+" "+this.Age;
        }
        #endregion

        #region propriété calculé
        public int Age
        {
            get
            {
                if ( this.DateNaissanceStagiaire == DateTime.MinValue ) return 0;
                if ( !this.DateNaissanceStagiaire.HasValue ) return 0;

                return DateTime.Today.DayOfYear < this.DateNaissanceStagiaire.Value.DayOfYear?DateTime.Today.Year - this.DateNaissanceStagiaire.Value.Year-1:DateTime.Today.Year - this.DateNaissanceStagiaire.Value.Year;
            }
        }
        #endregion
    }
}
