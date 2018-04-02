using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projet2_CSharp.database
{
public class Connection
    {
       readonly SQLiteAsyncConnection database;
        public Connection(string path)
        {
            
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Admin>();
            database.CreateTableAsync<Etudiant>();
            database.CreateTableAsync<Filiere>();
           
        }
        public Task<List<object>> GetItemsAsync()
        {
            return database.Table<object>().ToListAsync();
        }

        public Task<List<object>> GetItemsNotDoneAsync(string s)
        {
            return database.QueryAsync<object>(s);
        }

        public Task<Admin> GetItemAsync(int id)
        {
            return database.Table<Admin>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Admin item)
        {
            if (item.id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(object item)
        {
            return database.DeleteAsync(item);
        }

    }
}
