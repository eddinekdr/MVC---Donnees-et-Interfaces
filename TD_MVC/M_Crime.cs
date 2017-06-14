using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_MVC
{
    class M_Crime
    {
        private string id;
        private string date;
        private string borough;
        private int coord_X;
        private int coord_Y;
        private M_Crime_description crime_desc;
        private M_Juridiction jurisdiction;

        //Constructeurs de M_Criime        
        public M_Crime(string id, string date, string borough, int coord_X, int coord_Y, M_Crime_description crime_desc, M_Juridiction jurisdiction)
        {
            this.id = id;
            this.date = date;
            this.borough = borough;
            this.coord_X = coord_X;
            this.coord_Y = coord_Y;
            this.crime_desc = crime_desc;
            this.jurisdiction = jurisdiction;
        }
        public M_Crime()
        {
        }
        //Accessors en écriture en et lecture de Date
        public string Date
        {
            get{ return date;}
            set{ date = value; }
        }
        //Accessors en écriture en et lecture de Borough
        public string Borough
        {
            get{return borough;}
            set {borough = value;}
        }
        //Accessors en écriture en et lecture de Coord_X
        public int Coord_X
        {
            get {return coord_X; }
            set {coord_X = value;  }
        }
        //Accessors en écriture en et lecture de Coord_Y
        public int Coord_Y
        {
            get   { return coord_Y; }
            set{coord_Y = value;}
        }

        //Accessors en écriture en et lecture de Id
        public string Id
        {
            get { return id;   }
            set {id = value;}
        }
        //Accessors en écriture en et lecture de Crime_desc
        internal M_Crime_description Crime_desc
        {
            get {return crime_desc;}
            set{crime_desc = value; }
        }
        //Accessors en écriture en et lecture de Jurisdiction
        internal M_Juridiction Jurisdiction
        {
            get {  return jurisdiction;   }
            set {  jurisdiction = value;    }
        }
    }
}
