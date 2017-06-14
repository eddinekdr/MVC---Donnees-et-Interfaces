using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//La Sauvegarde s'effectue lorsque l'on ferme le fichier dans le debug
namespace TD_MVC
{
    class M_GestionDonnees
    {
        public List<M_Crime> RecupererCrimes(string date, string quartier, string id)
        {
            List<M_Crime> ListeC = new List<M_Crime>();
            M_Crime MCrime = new M_Crime();
            string borough;
            int coord_X;
            int coord_Y;
            //connection à la base de données Mysql
            string connectionString = "SERVER=localhost; PORT=3306; DATABASE=NY_Crimes; UId=esilvs6; PASSWORD=esilvs6;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            //Traitement des différenrs cas selon les textbox remplies
            if (id != "")
            {
                command.CommandText = "SELECT c.id, date, borough, coord_X, coord_Y, description, name FROM crime c, crime_description cd, jurisdiction j WHERE c.id = " + id + " AND cd.id = crime_description_id AND j.id = jurisdiction_id;";
            }
            else if(date != "" && quartier != "")
            {
                command.CommandText = "SELECT c.id, date, borough, coord_X, coord_Y, description, name FROM crime c, crime_description cd, jurisdiction j WHERE date = '" + date + "' AND borough = '" + quartier + "' AND cd.id = crime_description_id AND j.id = jurisdiction_id;";
            }
            else if (date == "" && quartier != "")
            {
                command.CommandText = "SELECT c.id, date, borough, coord_X, coord_Y, description, name FROM crime c, crime_description cd, jurisdiction j WHERE borough = '" + quartier + "' AND cd.id = crime_description_id AND j.id = jurisdiction_id;";
            }
            else if (date != "" && quartier == "")
            {
                command.CommandText = "SELECT c.id, date, borough, coord_X, coord_Y, description, name FROM crime c, crime_description cd, jurisdiction j WHERE date = '" + date + "' AND cd.id = crime_description_id AND j.id = jurisdiction_id;";
            }
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())
            {   
                M_Crime_description McrimeDesc = new M_Crime_description();
                M_Juridiction MJurisdiction = new M_Juridiction();
                id = reader.GetValue(0).ToString();
                date = reader.GetValue(1).ToString();
                borough = reader.GetValue(2).ToString();
                coord_X = int.Parse(reader.GetValue(3).ToString());
                coord_Y = int.Parse(reader.GetValue(4).ToString());
                McrimeDesc.Description = reader.GetValue(5).ToString();
                MJurisdiction.Name = reader.GetValue(6).ToString();

                MCrime = new M_Crime(id, date, borough, coord_X, coord_Y, McrimeDesc, MJurisdiction);
                ListeC.Add(MCrime);
            }
            connection.Close();
            return ListeC;
        }

        public void addCrime(string date, string quartier, string coord_X, string coord_Y, string desc, string desc_detail, string jurisdiction)
        {
            int id_crime = -1;
            int id_jurisdiction = -1;
            int id_crime_desc = -1;

            string connectionString = "SERVER=localhost; PORT=3306; DATABASE=NY_Crimes; UId=esilvs6; PASSWORD=esilvs6;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(id)FROM Jurisdiction;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_jurisdiction = (int.Parse(reader.GetValue(0).ToString())) + 1;
            }
            reader.Close();
            //Insertion d'un crime
            command.CommandText = "INSERT INTO Jurisdiction(id, name) VALUES ('" + id_jurisdiction + "', '" + jurisdiction + "');";
            command.ExecuteNonQuery();
            command.CommandText = "SELECT MAX(id) FROM crime_description;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_crime_desc = (int.Parse(reader.GetValue(0).ToString())) + 1; 
            }
            reader.Close();
            //Insertion d'un crime
            command.CommandText = "INSERT INTO crime_description(id, description, desc_specificity) VALUES ('" + id_crime_desc + "', '" + desc + "', '" + desc_detail + "'); ";
            command.ExecuteNonQuery();
            command.CommandText = "SELECT MAX(id) FROM crime;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_crime = (int.Parse(reader.GetValue(0).ToString())) + 1; 
            }
            reader.Close();
            //Insertion d'un crime
            command.CommandText = "INSERT INTO Crime(id, date, borough, coord_X, coord_Y, crime_description_id, jurisdiction_id) VALUES('" + id_crime + "', '" + date + "', '" + quartier + "', '" + coord_X + "', '" + coord_Y + "', '" + id_crime_desc + "', '" + id_jurisdiction + "');";
            command.ExecuteNonQuery();
            connection.Close();
        }

        //Fonction de sauvegarde sous la forme XML
        public void sauvegarderecherche(List<M_Crime> listMCrime, string date, string quartier, string id)
        {
            XmlDocument docXml = new XmlDocument();
            docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");
            XmlElement racine = docXml.CreateElement("resultats");
            docXml.AppendChild(racine);
            //Creation de l'élément "requête"
            XmlElement requete = docXml.CreateElement("requête");
            racine.AppendChild(requete);
            if (id != "")
            {
                XmlElement Id = docXml.CreateElement("id");
                Id.InnerText = id;
                requete.AppendChild(Id);
            }
            if (date != "")
            {
                XmlElement Date = docXml.CreateElement("date");
                Date.InnerText = date;
                requete.AppendChild(Date);
            }
            if (quartier != "")
            {
                XmlElement Quartier = docXml.CreateElement("borough");
                Quartier.InnerText = quartier;
                requete.AppendChild(Quartier);
            }
           foreach (M_Crime MCrime in listMCrime)
            {
                XmlElement Crime = docXml.CreateElement("Crime");
                racine.AppendChild(Crime);
                XmlElement Id = docXml.CreateElement("id");
                Id.InnerText = MCrime.Id;
                Crime.AppendChild(Id);
                XmlElement Date = docXml.CreateElement("date");
                Date.InnerText = MCrime.Date;
                Crime.AppendChild(Date);
                XmlElement Quartier = docXml.CreateElement("borough");
                Quartier.InnerText = MCrime.Borough;
                Crime.AppendChild(Quartier);
                XmlElement Coord_X = docXml.CreateElement("Coord_X");
                string cx = Convert.ToString(MCrime.Coord_X);
                Coord_X.InnerText = cx;
                Crime.AppendChild(Coord_X);
                XmlElement Coord_Y = docXml.CreateElement("Coord_Y");
                string cy = Convert.ToString(MCrime.Coord_Y);
                Coord_Y.InnerText = cy;
                Crime.AppendChild(Coord_Y);
                XmlElement Description = docXml.CreateElement("Description");
                Description.InnerText = MCrime.Crime_desc.Description;
                Crime.AppendChild(Description);

                XmlElement Jurisdiction = docXml.CreateElement("Jurisdiction");
                Jurisdiction.InnerText = MCrime.Jurisdiction.Name;
                Crime.AppendChild(Jurisdiction);
            }
            //Sauvegarde du XML dans dossier debug 
            docXml.Save("resultats.xml");
        }

    }
}
