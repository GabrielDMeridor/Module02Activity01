using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Activity01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Activity01.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _student;

        private string _fullName; //Variable for data conversion
        //Role of ViewModel
        public StudentViewModel()
        {
            // Initialize a samp;e student model. Coordination with Model
            _student = new Student { FirstName = "John", LastName = "Doe", Age = 23 };
            //UI Thread Management
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());

            Students = new ObservableCollection<Student>
            {
                new Student {FirstName="Juan", LastName="Smith", Age=23 },
                new Student {FirstName="Juan", LastName="Dela Cruz", Age=23 },
                new Student {FirstName="Pedro", LastName="Penduko", Age=23 },

            };

        }

        public ObservableCollection<Student> Students { get; set; }


    public string FullName
        {
            get => _fullName;
            set
            {
                if(_fullName != value) 
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
        //UI Thread Management
        public ICommand LoadStudentDataCommand { get;}

        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000); //I/O operation
            FullName = $"{_student.FirstName} {_student.LastName}"; //Data
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
