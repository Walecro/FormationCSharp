using Or.Business;
using Or.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Retrait.xaml
    /// </summary>
    public partial class AjouterBeneficiaire : PageFunction<long>
    {

        Compte _Cpt;
        public AjouterBeneficiaire(Compte Cpt)
        {
            InitializeComponent();

            //Recupérer la liste des comptes susceptibles  ?


            _Cpt = Cpt;
            

        }

        public void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            int cpt_dest = int.Parse(Compte.Text);
            //Verif =

            Compte compte_dest = SqlRequests.GetCompteFromID(cpt_dest);
            

            if (compte_dest.TypeDuCompte == _Cpt.TypeDuCompte && _Cpt.TypeDuCompte == TypeCompte.Courant && compte_dest.IdentifiantCarte != _Cpt.IdentifiantCarte)
            {
                // try catch unique
                SqlRequests.ConstructionInsertionBeneficiaire(_Cpt.Id, cpt_dest);

                PageFunctionNavigate(new ListeBeneficiaires(_Cpt));
            }
            else
            {
                MessageBox.Show("Compte Invalide");
            }

            
        }

        void PageFunctionNavigate(PageFunction<long> page)
        {
            page.Return += new ReturnEventHandler<long>(PageFunction_Return);
            NavigationService.Navigate(page);
        }

        void PageFunction_Return(object sender, ReturnEventArgs<long> e)
        {

        }

        // Cas spécial de retour modulaire 
        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            PageFunctionNavigate(new ListeBeneficiaires(_Cpt));

        }
    }
}
