using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_MVC
{
    class C_Ajouter
    {
        public void AddCrime(string date, string quartier, string coord_X, string coord_Y, string desc, string desc_detail, string jurisdiction)
        {
            M_GestionDonnees Gest_Donnees = new M_GestionDonnees();
            Gest_Donnees.addCrime(date, quartier, coord_X, coord_Y, desc, desc_detail, jurisdiction);
        }
    }
}