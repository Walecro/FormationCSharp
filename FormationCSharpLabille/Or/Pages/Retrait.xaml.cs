using Or.Business;
using Or.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Retrait.xaml
    /// </summary>
    public partial class Retrait : PageFunction<long>
    {
        Carte CartePorteur { get; set; }
        Compte ComptePorteur { get; set; }
        public Retrait(long numCarte)
        {
            InitializeComponent();
            Montant.Text = 0M.ToString("C2");

            CartePorteur = SqlRequests.InfosCarte(numCarte);
            ComptePorteur = SqlRequests.ListeComptesAssociesCarte(CartePorteur.Id).Find(x => x.TypeDuCompte == TypeCompte.Courant);
            List<Transaction> transac = SqlRequests.ListeTransactionsAssociesCarte(numCarte);
            List<int> cpts = SqlRequests.ListeComptesAssociesCarte(numCarte).Select(x => x.Id).ToList();
            CartePorteur.AlimenterHistoriqueEtListeComptes(transac, cpts);


            PlafondRetraitMaxActuel.Text = SoldeCarteActuel(DateTime.Now, transac).ToString("C2");
            PlafondMaxRetrait.Text = CartePorteur.Plafond.ToString("C2");
            Solde.Text = ComptePorteur.Solde.ToString("C2");
        }

        private decimal SoldeCarteActuel(DateTime dt, List<Transaction> transac)
        {
            // Penser à prendre que les opérations où les comptes de la carte sont expéditeurs !
            decimal cum = transac
                .Where(x =>
                    x.Horodatage > dt.AddDays(-10)
                    && x.Expediteur != 0
                    && x.Destinataire == 0)
                .Sum(x => x.Montant);
            /*foreach (Transaction t in transac)
            {
                delta = (dt - t.Horodatage).TotalDays;
                if (delta <= 10 && delta >= 0)
                {
                    cum += t.Montant;
                }

            }*/
            return Math.Min(CartePorteur.Plafond - cum, ComptePorteur.Solde);

        }
        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        private void ValiderRetrait_Click(object sender, RoutedEventArgs e)
        {
            List<Transaction.CodeResultat> codeResultat = new List<Transaction.CodeResultat>();
            // T tmp 
            Transaction t = new Transaction(0, DateTime.Now, 0, ComptePorteur.Id, 0);

            if (decimal.TryParse(Montant.Text.Replace(".", ",").Trim(new char[] { '€', ' ' }), out decimal montant) && montant > 0)
            {
                //Compte fictif pour permettre la transaction
                Compte compteBanque = new Compte(0, 0, TypeCompte.Courant, 0);
                t.Montant = montant;
                t.Destinataire = compteBanque.Id;


                // Potentiel réassignation de Valide mais c'est OK
                codeResultat.Add(CartePorteur.EstRetraitAutoriseNiveauCarte(t, compteBanque, ComptePorteur));
                if (!ComptePorteur.EstRetraitValide(t))
                {
                    codeResultat.Add(Transaction.CodeResultat.SoldeKO);
                }

            }
            else
            {
                codeResultat.Add(Transaction.CodeResultat.MontantKO);
            }

            if (codeResultat.Count == 1 && codeResultat[0] == Transaction.CodeResultat.Valide)
            {
                SqlRequests.EffectuerModificationOperationSimple(t, CartePorteur.Id);

                OnReturn(null);
            }
            else
            {
                foreach (Transaction.CodeResultat code in codeResultat)
                {
                    MessageBox.Show(Label(code));

                }
            }
        }
        private string Label(Transaction.CodeResultat cr)
        {
            string ret = "";

            switch (cr)
            {
                case Transaction.CodeResultat.MontantKO:
                    ret = "Montant invalide";
                    break;
                case Transaction.CodeResultat.SoldeKO:
                    ret = "Solde insuffisant";
                    break;
                /*
            case Transaction.CodeResultat.DestinataireKO:
                ret = "Opération intercompte invalide";
                break;
                */
                case Transaction.CodeResultat.PlafondKO:
                    ret = "Plafond carte insuffisant";
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
