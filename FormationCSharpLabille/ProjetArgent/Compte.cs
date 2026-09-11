using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{


    public class Compte
    {
        public enum TypeCompte
        {
            Courant,
            Livret
        }

        int _ID { get;}
        double _Solde { get; set; }
        TypeCompte _type { get; set; }
        Carte _carte { get; set; }

       
        public Compte(int id,TypeCompte type, Carte carte, double solde=0)
        {
            _ID = id;
            _Solde = solde;
            _carte = carte;

            _type = type;

        }

        public new string ToString()
        {
            return _ID + " " + _carte._numcarte + " " + _type + " " + _Solde;
        }

        public bool Depot(double mnt)
        {
            if (mnt < 0.0)
            {
                _Solde += mnt;
                return true;
            }
            return false;
        }


        public bool Retrait(double mnt)
        {
            if (mnt < 0.0 && _carte.CheckPlafond(mnt)  )
            {
                
                _Solde -= mnt;
                return true;
            }
            return false;
        }

        public bool Prelevement(Compte cpt)
        {
            return false;
        }

        public bool Virement(Compte cpt)
        {

            return false;
        }


    }
}
