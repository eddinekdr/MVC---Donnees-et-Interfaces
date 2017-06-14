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
    /// Logique d'interaction pour V_Ajout.xaml
    /// </summary>
    public partial class V_Ajout : Window
    {
        private C_Ajouter mv;
        public V_Ajout()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            mv = new C_Ajouter();
            if (D.Text == "" || Q.Text == "" || cx.Text == "" || cy.Text == "" || desc.Text == "" || desc_detail.Text == "" || J.Text == "")
            {
                MessageBox.Show("Veuillez remplir tout les champs");
            }
            else
            {
                try
                {
                    int coord_X = int.Parse(cx.Text);
                    int coord_Y = int.Parse(cy.Text);
                }
                catch
                {
                    MessageBox.Show("Entrez un nombre entier pour les champs Coord_X et Coord_Y");
                    return;
                }
                mv.AddCrime(D.Text, Q.Text, cx.Text, cy.Text, desc.Text, desc_detail.Text, J.Text);
                MessageBox.Show("Ajout fait");
            }
        }
    }
}
