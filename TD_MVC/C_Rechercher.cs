using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_MVC
{
    class C_Rechercher : INotifyCollectionChanged, IEnumerable //Application des interfaces
    {
        private List<C_Crime> listeCrime;
        //Récupérer la liste des résultats dans C_Rechercher
        public C_Rechercher()
        {
            listeCrime = new List<C_Crime>();
        }
        public void RecupCrime(string date, string quartier, string id)
        {
            M_GestionDonnees Gest_Donnees = new M_GestionDonnees();
            List<M_Crime> ListeC = Gest_Donnees.RecupererCrimes(date, quartier, id);
            //Recuperer les crimes dans M_Crime
            //liste principale de C_Crime
            foreach (M_Crime MCrime in ListeC)
            {
                C_Crime newCCrime = new C_Crime();
                newCCrime.Id = MCrime.Id;
                newCCrime.Date = MCrime.Date;
                newCCrime.Borough = MCrime.Borough;
                newCCrime.Coord_X = MCrime.Coord_X;
                newCCrime.Coord_Y = MCrime.Coord_Y;
                newCCrime.Crime_desc = MCrime.Crime_desc;
                newCCrime.Jurisdiction = MCrime.Jurisdiction;
                listeCrime.Add(newCCrime); 
                this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newCCrime));
            }
            Gest_Donnees.sauvegarderecherche(ListeC, date, quartier, id); //Fonction de sauvegarde sous la forme XML
        }
        //Implementation de l'interface
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if(this.CollectionChanged != null)
            {
                this.CollectionChanged(this, args);
            }
        }
        //Les interfaces sont toujours publics
        public IEnumerator GetEnumerator()
        {
            return listeCrime.GetEnumerator();
        }
    }
}
