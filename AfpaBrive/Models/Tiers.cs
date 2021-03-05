using AfpaBrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAfpa
{
    public class Tiers:Personne
    {
        public Tiers()
        {
            PeeIdResponsableJuridiqueNavigations = new HashSet<Pee>();
            PeeIdTuteurNavigations = new HashSet<Pee>();
        }
        public virtual ICollection<Pee> PeeIdResponsableJuridiqueNavigations { get; set; }
        public virtual ICollection<Pee> PeeIdTuteurNavigations { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Tiers tiers &&
                   IdPersonne == tiers.IdPersonne;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdPersonne);
        }
    }
}
