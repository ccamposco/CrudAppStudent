using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrudAppStudent.Data
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "StudentDB.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(dbPath, dbName);
            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
