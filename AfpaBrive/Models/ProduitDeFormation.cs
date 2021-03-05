using System;
using System.Collections.Generic;

#nullable disable

namespace AfpaBrive
{
    public partial class ProduitDeFormation
    {
        public ProduitDeFormation()
        {
            OffreFormations = new HashSet<OffreFormation>();
        }

        public string IdProduitFormation { get; set; }
        public string DesignationProduitFormation { get; set; }
        public int TypeFormation { get; set; }
        public int? NiveauFormation { get; set; }
        public bool? InterEntreprise { get; set; }
        public int? DureeJours { get; set; }

        public virtual ICollection<OffreFormation> OffreFormations { get; set; }
    }
}
