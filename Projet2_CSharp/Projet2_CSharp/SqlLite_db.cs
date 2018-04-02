using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projet2_CSharp
{
    public interface SqlLite_db
    {
        SQLiteConnection GetConnection();
        string GetLocalFilePath(string filename);
    }
}
