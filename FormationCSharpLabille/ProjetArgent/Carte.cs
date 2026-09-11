using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Carte
    {
        internal string _numcarte{ get; }
        internal List<Compte> _Liste_Cpt { get; set; }

        internal List<Transaction> _Historique { get; set; }

        internal double _plafond;


        public Carte(string num,double plafond=500)
        {
            _numcarte = num;
            _plafond = plafond;
            _Liste_Cpt = new List<Compte>();
            _Historique = new List<Transaction>();
        }

        /// <summary>
        /// Méthode appelé par la carte d'un compte débiteur
        /// Renvoie true si  le plafond est respecté, false sinon
        /// </summary>
        /// <param name="transaction">Possede l'dentifiant unique du compte débiteur ainsi que le montant</param>
        /// <returns></returns>
        public bool CheckPlafond(double amount)
        {
            //check historique sur 10 jour  + ajout à l'historique ? 
            return true; 
        }

        public new string ToString()
        {
            return _numcarte + " " + _plafond;
        }
      
    }
}
