using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Identity
{
    public class AfpaStagiaire : IdentityUser
    {
        [PersonalData]
        public string Matricule { get; set; }
    }

    //public class AfpaColaborateur: IdentityUser
    //{
    //    [PersonalData]
    //    public string MatriculeCollaborateurAfpa { get; set; }
    //}
}
