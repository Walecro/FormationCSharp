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

        //Liste des transactions validées sur la carte
        internal List<Transaction> _Historique { get; set; }

        internal double _plafond;


        public Carte(string num,double plafond=500)
        {
            _numcarte = String.Copy(num);
            _plafond = plafond;
            _Liste_Cpt = new List<Compte>();
            _Historique = new List<Transaction>();
        }

        /// <summary>
        /// Méthode appelé par la carte d'un compte débiteur <br></br>
        /// </summary>
        /// <param name="transaction">Possede l'dentifiant unique du compte débiteur ainsi que le montant</param>
        /// <returns>True si  le plafond est respecté, false sinon</returns>
        public bool CheckPlafond(Transaction t)
        {
            //_Historique.Sort((x, y) => DateTime.Compare(x._horodatage, y._horodatage));
            double cum = 0;
            double cmp;
            bool ok = false;

            foreach (Transaction trans_past in _Historique)
            {
                //La transaction s'est elle produite dans les 10 derniers jours ? Si oui on la prend en compte
                cmp = (t._horodatage - trans_past._horodatage).TotalDays;
                if(cmp < 10.0 && cmp >= 0)
                {
                    cum += t._montant ;
                }
            }

            if(t._montant + cum < _plafond)
            {
                ok = true;
            }


            return ok; 
        }

        public new string ToString()
        {
            return _numcarte + " " + _plafond;
        }
      
    }
}
