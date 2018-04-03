using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projet2_CSharp.database
{
    public class Etudiant
    {
        [PrimaryKey]
        public string cne { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string sexe { get; set; }
  
        public DateTime date_naissance { get; set; }
        public int id_fil { get; set; }

        public override string ToString()
        {
            return string.Format("[Etudiant: cne={0}, nom={1}, prenom={2}, image={3},date_naissance={4},id_fil={5}]", cne, nom, prenom, sexe, date_naissance, id_fil);
        }
    }
}
