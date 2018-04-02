using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using Android.Widget;
using SQLite;
using Projet2_CSharp.Droid.data;

[assembly: Dependency(typeof(Sqlite_Andriod))]
namespace Projet2_CSharp.Droid.data
{
    public class Sqlite_Andriod : SqlLite_db
    {
        public SQLiteConnection GetConnection()
        {
            var s = "Gestion.db3";
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),s);
            var cnx = new SQLiteConnection(dbPath);
            return cnx;
        }
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}