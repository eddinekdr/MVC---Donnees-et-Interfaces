using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_MVC
{
    class M_Juridiction
    {
        private string id;
        private string name;
        //Constructeur
        public M_Juridiction(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public M_Juridiction()
        {
        }
        //Accesseurs en lecture et en ecriture de Id
        public string Id
        {
            get { return id;   }
            set  {id = value;}
        }
        //Accesseurs en lecture et en ecriture de Name
        public string Name
        {
            get{return name; }
            set{ name = value; }
        }
    }
}
