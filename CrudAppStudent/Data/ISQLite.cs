using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudAppStudent.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
