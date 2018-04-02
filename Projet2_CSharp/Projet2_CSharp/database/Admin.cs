using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Projet2_CSharp.database
{
    public class Admin
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return string.Format("[Admin: id={0}, login={1}, password={2}]", id, login, password);
        }

    }
}
