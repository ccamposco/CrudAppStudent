using CrudAppStudent.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CrudAppStudent.Data
{
    public class DataLogic
    {
        private SQLiteConnection conn;
        private Student student;

        public DataLogic()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Student>();
        }

        public bool SavetoDB(string firstname, string lastname, string email)
        {
            student = new Student
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };

            try
            {
                conn.Insert(student);
                conn.Close();
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception) { }
            return false;
        }

        public IEnumerable<Student> ShowData()
        {
            var lstStudent = from student in conn.Table<Student>() select student;
            return lstStudent;
        }

    }
}
