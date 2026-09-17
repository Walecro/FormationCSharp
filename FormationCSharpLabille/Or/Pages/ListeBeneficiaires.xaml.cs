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
    public partial class ListeBeneficiaires { 
        public ListeBeneficiaires(long NumCarte)
        {
            InitializeComponent();

            Numero.Text = NumCarte.ToString();

            listView.ItemsSource = SqlRequests.ListeBeneficiaire(NumCarte);

        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }


        void PageFunctionNavigate(PageFunction<long> page)
        {
            page.Return += new ReturnEventHandler<long>(PageFunction_Return);
            NavigationService.Navigate(page);
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


    }

    }

