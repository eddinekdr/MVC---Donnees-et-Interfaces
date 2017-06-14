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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TD_MVC
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        V_Ajout addDelit;
        V_Recherche rechDelit;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AjoutDelit(object sender, RoutedEventArgs e)
        {
            addDelit = new V_Ajout();
            addDelit.Show();
        }

        private void RechercherDelit_Click(object sender, RoutedEventArgs e)
        {
            rechDelit = new V_Recherche();
            rechDelit.Show();
        }
    }
}
