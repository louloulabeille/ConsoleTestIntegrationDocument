using System;
using System.Collections.Generic;

#nullable disable

namespace AfpaBrive
{
    public partial class Pee
    {
        public Pee()
        {
            PeriodePees = new HashSet<PeriodePee>();
        }

        public int IdPee { get; set; }
        public int IdStagiaire { get; set; }
        public int IdTuteur { get; set; }
        public int IdResponsableJuridique { get; set; }
        public int IdEntreprise { get; set; }
        public int IdOffreFormation { get; set; }

        public virtual Entreprise IdEntrepriseNavigation { get; set; }
        public virtual Personne IdResponsableJuridiqueNavigation { get; set; }
        public virtual Personne IdStagiaireNavigation { get; set; }
        public virtual Personne IdTuteurNavigation { get; set; }
        public virtual ICollection<PeriodePee> PeriodePees { get; set; }
    }
}
