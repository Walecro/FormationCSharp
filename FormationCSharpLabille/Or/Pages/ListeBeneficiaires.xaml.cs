using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Or.Business;
using Or.Models;

namespace Or.Pages
{
    /// <summary>
    /// Logique ht'interaction pour ConsultationCarte.xaml
    /// </summary>
    
    public partial class ListeBeneficiaires
    {

        Compte _Cpt;
        public ListeBeneficiaires(Compte Cpt)
        {
            InitializeComponent();
            _Cpt = Cpt;
            Numero.Text = _Cpt.IdentifiantCarte.ToString();

            listView.ItemsSource = SqlRequests.ListeBeneficiaire(_Cpt.IdentifiantCarte);

        }

  

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            PageFunctionNavigate(new ConsultationCarte(long.Parse(Numero.Text)));
        }


        void PageFunctionNavigate(PageFunction<long> page)
        {
            page.Return += new ReturnEventHandler<long>(PageFunction_Return);
            NavigationService.Navigate(page);
        }

        private void GoAjouterBeneficiaire_Click(object sender, RoutedEventArgs e)
        {
            PageFunctionNavigate(new AjouterBeneficiaire(_Cpt));
        }

        void PageFunction_Return(object sender, ReturnEventArgs<long> e)
        {

        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridView gridView = listView.View as GridView;
            if (gridView != null)
            {
                double totalWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;

            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            //Reste à récupérer la ligne sélectionnée actuellement 
            int idt_benef = (int)(((Beneficiaire)listView.Items[0]).Id_Cpt_benef);
            int idt_cpt = _Cpt.Id;

            long numcarte = long.Parse(Numero.Text);
            
            SqlRequests.ConstructionDeleteBeneficiaire(idt_cpt, idt_benef);

            listView.ItemsSource = SqlRequests.ListeBeneficiaire(numcarte);



        }
    }
}

