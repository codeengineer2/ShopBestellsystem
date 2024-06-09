using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Shop_bestellsystem
{
    /// <summary>
    /// Interaktionslogik für UserAgreementWindow.xaml
    /// </summary>
    public partial class UserAgreementWindow : Window
    {
       
        public UserAgreementWindow()
        {
            Loggerclass.logger.Information("Agreements Window initialized.");
            InitializeComponent();
        }

    

        private void decline_Click(object sender, RoutedEventArgs e)
        {
            Loggerclass.logger.Fatal("Projekt beendet -- Da die UserAgreements nicht Akzeptiert wurden");
            Environment.Exit(0);
        }

        private void agree_Click(object sender, RoutedEventArgs e)
        {
            if (agb.IsChecked == true && useragreement.IsChecked == true)
            {
                Loggerclass.logger.Information("Beide Agreements wurden Akzeptiert -- AGBs und UserAgreement");
                agb.BorderBrush = Brushes.Black;
                this.Close();
            }
            else
            {
                if (agb.IsChecked == false)
                {
                    Loggerclass.logger.Warning("AGB wurde abgelehnt!");
                    agb.BorderBrush = Brushes.Red;
                    
                }
                else
                {
                    Loggerclass.logger.Warning("AGB wurde akzeptiert!");
                    agb.BorderBrush = Brushes.Black;
                }
                if (useragreement.IsChecked == false)
                {
                    Loggerclass.logger.Warning("User Agreement wurde abgelehnt!");
                    useragreement.BorderBrush = Brushes.Red;
                }
                else
                {
                    Loggerclass.logger.Warning("User Agreement wurde akzeptiert!");
                    useragreement.BorderBrush = Brushes.Black;
                }
               

            }
        }
    }
}
