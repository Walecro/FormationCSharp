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

        int _ID;
        
        public int ID{
            get { return _ID; }
        }
        internal double _Solde { get; set; }
        internal TypeCompte _type { get; set; }
        internal Carte _carte { get; set; }

       
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

        /// <summary>
        /// Opération élémentaire d'addition sur l'objet Compte
        /// </summary>
        /// <param name="mnt">Le montant à ajouter</param>
        public void Depot(double mnt)
        {
            if (mnt > 0.0)
            {
                _Solde += mnt;
            }
        }

        /// <summary>
        /// Opération élémentaire de soustraction sur l'objet Compte
        /// </summary>
        /// <param name="mnt">Le montant à retirer</param>
        public void Retrait(double mnt)
        {
            if (mnt > 0.0 )
            {
                _Solde -= mnt;
            }
        }

        /// <summary>
        /// Fonction vérifiant le plafond de la carte et effectuant le prélévement sur le compte appelé si valide
        /// Retire le montant correspondant sur le compte appelé
        /// Ajoute la transaction actuelle à l'historique de la carte si vrai
        /// </summary>
        /// <returns>True si l'opération s'est bien déroulée false sinon</returns>
        public bool Prelevement(Transaction t)
        {
            bool ok = false;

            if (_carte.CheckPlafond(t) && _Solde >= t._montant){
                Retrait(t._montant);
                // this, emetteur
                _carte._Historique.Add(t);

                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// Fonction effectuant le virement sur le compte appelé
        /// Ajoute le montant correspondant sur le compte appelé
        /// </summary>
        public void Virement(Transaction t)
        {
            Depot(t._montant);
        }


    }
}
