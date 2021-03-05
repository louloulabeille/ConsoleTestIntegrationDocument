using System;
using System.Collections.Generic;

#nullable disable

namespace AfpaBrive
{
    public partial class Personne
    {
        public Personne()
        {
            //OffreFormations = new HashSet<OffreFormation>();
            //PeeIdResponsableJuridiqueNavigations = new HashSet<Pee>();
            //PeeIdStagiaireNavigations = new HashSet<Pee>();
            //PeeIdTuteurNavigations = new HashSet<Pee>();
            //StagiaireOffreFormations = new HashSet<StagiaireOffreFormation>();
        }

        public int IdPersonne { get; set; }
        public string NomPersonne { get; set; }
        public string PrenomPersonne { get; set; }
        public string CivilitePersonne { get; set; }
        public int SexePersonne { get; set; }
        public string AdresseMail { get; set; }
        public string CatPersonne { get; set; }
        //public string MatriculeCollaborateurAfpa { get; set; }
        //public string MatriculeStagiaire { get; set; }
        //public DateTime? DateNaissanceStagiaire { get; set; }

        //public virtual ICollection<OffreFormation> OffreFormations { get; set; }
        //public virtual ICollection<Pee> PeeIdResponsableJuridiqueNavigations { get; set; }
        //public virtual ICollection<Pee> PeeIdStagiaireNavigations { get; set; }
        //public virtual ICollection<Pee> PeeIdTuteurNavigations { get; set; }
        //public virtual ICollection<StagiaireOffreFormation> StagiaireOffreFormations { get; set; }
    }
}
