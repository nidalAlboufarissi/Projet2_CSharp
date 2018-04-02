using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projet2_CSharp.database
{
    public class Filiere
    {
        [PrimaryKey, AutoIncrement]
        public int id_filiere { get; set; }
        public string nom_filiere { get; set; }
        public string responsable { get; set; }

        public override string ToString()
        {
            return string.Format("[Filiere: id_filiere={0}, nom_filiere={1}, responsable={2}]", id_filiere, nom_filiere, responsable);
        }
    }
}
