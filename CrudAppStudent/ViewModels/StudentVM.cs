using CrudAppStudent.Data;
using CrudAppStudent.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudAppStudent.ViewModels
{
    public class StudentVM : BaseViewModel
    {
        public Command _SaveCommand;
        public Command _ShowCommand;

        private string _firstnameProp;
        private string _lastnameProp;
        private string _emailProp;

        ObservableCollection<Student> students = new ObservableCollection<Student>();

        public ObservableCollection<Student> Students
        {
            get { return students; }
        }

        public StudentVM() { }

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new Command(SavetoDB);                     
                }
                return _SaveCommand;
            }
        }

        public ICommand ShowCommand
        {
            get
            {
                if (_ShowCommand == null)
                {
                    _ShowCommand = new Command(ShowData);
                }
                return _ShowCommand;
            }
        }

        public string FirstNameProp 
        { 
            get => _firstnameProp;
            set
            {
                if (_firstnameProp != value)
                {
                    _firstnameProp = value;
                }
                OnPropertyChanged();
            }
        }

        public string LastNameProp {
            get => _lastnameProp;
            set
            {
                if (_lastnameProp != value)
                {
                    _lastnameProp = value;
                }
                OnPropertyChanged();
            }
        }
        public string EmailProp {
            get => _emailProp;
            set
            {
                if (_emailProp != value)
                {
                    _emailProp = value;
                }
                OnPropertyChanged();
            }
        }

        private void SavetoDB()
        {
            var firstName = FirstNameProp;
            var lastName = LastNameProp;
            var email = EmailProp;

            DataLogic dl = new DataLogic();
            bool success = dl.SavetoDB(firstName, lastName, email);
            if (success)
            {
                FirstNameProp = string.Empty;
                LastNameProp = string.Empty;
                EmailProp = string.Empty;
            }
        }

        private void ShowData()
        {
            DataLogic dataLogic = new DataLogic();
            var lstStudent = dataLogic.ShowData();

            foreach(var studentDetails in lstStudent)
            {
                Student student = new Student
                {
                    Id = studentDetails.Id,
                    FirstName = studentDetails.FirstName,
                    LastName = studentDetails.LastName,
                    Email = studentDetails.Email,
                };

                Students.Add(student);
            }

        }
    }
}