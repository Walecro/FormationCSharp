using Or.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Or.Models
{
    public class Beneficiaire
    {

        public long Id_Cpt { get; set; }

        public long Id_Cpt_benef { get; set; }

        public string prenom { get; set; }
        public string nom { get; set; }

        
        public Beneficiaire(int id, int id_b , string pr, string n)
        {
            Id_Cpt = id;
            Id_Cpt_benef = id_b;

            prenom = pr;
            nom = n;
            
        }

    }
}