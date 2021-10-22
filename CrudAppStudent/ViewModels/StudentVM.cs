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

        public ICommand SaveComannd
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
        }
    }
}