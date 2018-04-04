using Projet2_CSharp.database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projet2_CSharp
{
    public class DbController
    {
        static object locker = new object();
        SQLiteAsyncConnection db;
        //public DbController()
        //{
        //    db = DependencyService.Get<SqlLite_db>().GetConnection();
        //    db.CreateTable<Admin>();
        //    if(db.Table<Admin>().Count()==0)
        //    {
        //        Admin d = new Admin();

        //        d.login = "hakim";
        //        d.password = "nidal";
        //        db.Insert(d);

        //    }

        //}
        public DbController(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Admin>().Wait();
            db.CreateTableAsync<Filiere>().Wait();
            db.CreateTableAsync<Etudiant>().Wait();

            /* db.DeleteAsync(new Filiere() { nom_filiere="informatique" ,id_filiere=4});
             db.DeleteAsync(new Filiere() { nom_filiere = "GTR", id_filiere=5 });
             db.DeleteAsync(new Filiere() { nom_filiere = "Mecanique", id_filiere=6 });*/
            db.InsertAsync(new Etudiant() { cne = "452", nom = "aitelhad", prenom = "abdelhakim", date_naissance = DateTime.Now, sexe = "Male", id_fil = 1 });



        }
        public Task<Filiere> GetFilById(int id)
        {
            return db.Table<Filiere>().Where(i => i.id_filiere == id).FirstOrDefaultAsync();
        }
        public Task<List<Etudiant>> GetEtudByFil(int id)
        {
            return db.Table<Etudiant>().Where(i => i.id_fil == id).ToListAsync();
        }
        public Task<Filiere> GetFilByName(string name)
        {
            return db.Table<Filiere>().Where(i => i.nom_filiere == name).FirstOrDefaultAsync();
        }

        public Task<Admin> GetItemAsync(int id)
        {
            return db.Table<Admin>().Where(i => i.id == id).FirstOrDefaultAsync();
        }
        public Task<Admin> Login(Admin ad)
        {
            return db.Table<Admin>().Where(i => i.login == ad.login && i.password == ad.password).FirstOrDefaultAsync();

        }
        public Task<List<Filiere>> GetAllFils()
        {
            return db.Table<Filiere>().ToListAsync();
        }
        public Task<List<Etudiant>> GetAllEtudiants()
        {
            return db.Table<Etudiant>().ToListAsync();
        }
        public Task<int> delete(object d)
        {
            return db.DeleteAsync(d);
        }
        public Task<int> SaveItemAsync(Admin item)
        {
            if (item.id != 0)
            {
                return db.UpdateAsync(item);
            }
            else
            {
                return db.InsertAsync(item);
            }
        }
        public Task<int> SaveFiliere(Filiere item)
        {
            if (item.id_filiere != 0)
            {
                return db.UpdateAsync(item);
            }
            else
            {
                return db.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsync(Etudiant item)
        {

            return db.InsertAsync(item);

        }
        public Task<int> UpdatEtud(Etudiant item)
        {

            return db.UpdateAsync(item);

        }
    }
}
