using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_MVC
{
    class M_Crime_description
    {
        private string id;
        private string description;
        private string desc_specificity;

        //Constructeur
        public M_Crime_description(string id, string description, string desc_specificity)
        {
            this.id = id;
            this.description = description;
            this.desc_specificity = desc_specificity;
        }
        public M_Crime_description()
        {
        }
        //Accesseurs en lecture et en ecriture de Description
        public string Description
        {
            get {  return description; }
            set {description = value; }
        }
        //Accesseurs en lecture et en ecriture de Desc_specificity
        public string Desc_specificity
        {
            get { return desc_specificity;    }
            set { desc_specificity = value; }// a voir
        }
        //Accesseurs en lecture et en ecriture de Id
        public string Id
        {
            get{return id;}
            set{id = value; }
        }

     

       
    }
}
