using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Transaction
    {

        int _id;
        DateTime _horodatage;
        double _montant;
        int _cpt_exp;
        int _cpt_dest;

        public Transaction(int id,DateTime horodatage,double montant,int cpt_exp,int cpt_dest)
        { 
            _id = id;
            _horodatage = horodatage;
            _montant = montant;
            _cpt_exp = cpt_exp;
            _cpt_dest = cpt_dest;

        }


    }
}
