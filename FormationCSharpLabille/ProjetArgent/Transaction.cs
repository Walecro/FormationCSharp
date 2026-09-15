using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Transaction
    {

        internal int _id;
        internal DateTime _horodatage;
        internal double _montant;
        internal int _cpt_exp;
        internal int _cpt_dest;

        public Transaction(int id,DateTime horodatage,double montant,int cpt_exp,int cpt_dest)
        { 
            _id = id;
            _horodatage = horodatage;
            _montant = montant;
            _cpt_exp = cpt_exp;
            _cpt_dest = cpt_dest;

        }

        public new string ToString()
        {
            return _id + " " + _horodatage + " " + _montant + " de " + _cpt_exp + " vers " + _cpt_dest;
        }

       
    }
}
