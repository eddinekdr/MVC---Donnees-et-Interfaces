using MySql.Data.MySqlClient;
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

namespace TD_MVC
{
    /// <summary>
    /// Logique d'interaction pour MV_Rechercher.xaml
    /// </summary>
    public partial class V_Recherche : Window
    {
        private C_Rechercher mv;

        public V_Recherche()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mv = new C_Rechercher();

            mv.RecupCrime(textBox_D.Text, textBox_Q.Text, textBox_I.Text);

            listView.ItemsSource = mv; //Affichage de dans la listView
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
