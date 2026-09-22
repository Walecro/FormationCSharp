using Or.Business;
using Or.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Collections.Generic;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Virement.xaml
    /// </summary>
    public partial class Virement : PageFunction<long>
    {

        Carte CartePorteur { get; set; }
        Compte ComptePorteur { get; set; }
        public Virement(long numCarte)
        {
            InitializeComponent();

            Montant.Text = 0M.ToString("C2");

            CartePorteur = SqlRequests.InfosCarte(numCarte);
            CartePorteur.AlimenterHistoriqueEtListeComptes(SqlRequests.ListeTransactionsAssociesCarte(numCarte), SqlRequests.ListeComptesAssociesCarte(CartePorteur.Id).Select(x=>x.Id).ToList());
            ComptePorteur = SqlRequests.ListeComptesAssociesCarte(CartePorteur.Id).Find(x => x.TypeDuCompte == TypeCompte.Courant);

            var viewExpediteur = CollectionViewSource.GetDefaultView(SqlRequests.ListeComptesAssociesCarte(numCarte));
            viewExpediteur.GroupDescriptions.Add(new PropertyGroupDescription("TypeDuCompte"));
            viewExpediteur.SortDescriptions.Add(new SortDescription("TypeDuCompte", ListSortDirection.Ascending));
            viewExpediteur.SortDescriptions.Add(new SortDescription("IdentifiantCarte", ListSortDirection.Ascending));
            Expediteur.ItemsSource = viewExpediteur;

            var viewDestinataire = CollectionViewSource.GetDefaultView(SqlRequests.ListeComptesDispo(ComptePorteur.Id));
            viewDestinataire.GroupDescriptions.Add(new PropertyGroupDescription("IdentifiantCarte"));
            viewDestinataire.SortDescriptions.Add(new SortDescription("IdentifiantCarte", ListSortDirection.Ascending));
            viewDestinataire.SortDescriptions.Add(new SortDescription("TypeDuCompte", ListSortDirection.Ascending));
            Destinataire.ItemsSource = viewDestinataire;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        private void ValiderVirement_Click(object sender, RoutedEventArgs e)
        {
            List<Transaction.CodeResultat> codes = new List<Transaction.CodeResultat>();

            Compte ex = Expediteur.SelectedItem as Compte;
            Compte de = Destinataire.SelectedItem as Compte;
            Transaction t = new Transaction(0, DateTime.Now, 0, ex.Id, de.Id);
            if (decimal.TryParse(Montant.Text.Replace(".", ",").Trim(new char[] { '€', ' ' }), out decimal montant))
            { 
                t.Montant = montant;

                if ( ! (Expediteur.SelectedItem as Compte).EstRetraitValide(t)) {

                    codes.Add(Transaction.CodeResultat.SoldeKO);
                    
                }
                codes.Add(CartePorteur.EstRetraitAutoriseNiveauCarte(t, ex, de));

            }
            else
            {

                codes.Add(Transaction.CodeResultat.MontantKO);
            }

            if (codes.Count == 1 && codes[0] == Transaction.CodeResultat.Valide)
            {
                SqlRequests.EffectuerModificationOperationInterCompte(t, ex.IdentifiantCarte, de.IdentifiantCarte);
                OnReturn(null);
            }
            else
            {

                foreach (Transaction.CodeResultat code in codes)
                {
                    MessageBox.Show(Label(code));

                }
            }


        }

        private void Expediteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewDestinataire = CollectionViewSource.GetDefaultView(SqlRequests.ListeComptesDispo((Expediteur.SelectedItem as Compte).Id));
            viewDestinataire.GroupDescriptions.Add(new PropertyGroupDescription("IdentifiantCarte"));
            viewDestinataire.SortDescriptions.Add(new SortDescription("IdentifiantCarte", ListSortDirection.Descending));
            viewDestinataire.SortDescriptions.Add(new SortDescription("TypeDuCompte", ListSortDirection.Ascending));
            Destinataire.ItemsSource = viewDestinataire;
        }

        private void GoAjouterBeneficiaire_Click(object sender, RoutedEventArgs e)
        {
            PageFunctionNavigate(new AjouterBeneficiaire(ComptePorteur)); 
        }


        void PageFunctionNavigate(PageFunction<long> page)
        {
            page.Return += new ReturnEventHandler<long>(PageFunction_Return);
            NavigationService.Navigate(page);
        }

        void PageFunction_Return(object sender, ReturnEventArgs<long> e)
        {
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
                    case Transaction.CodeResultat.DestinataireKO:
                        ret = "Opération intercompte invalide";
                        break;
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
