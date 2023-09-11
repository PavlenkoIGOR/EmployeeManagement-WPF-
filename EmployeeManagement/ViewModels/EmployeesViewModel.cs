using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmployeeManagement.ViewModels
{
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) //данный метод необходимо вызывать везде, где необходима двусторонняя привязка
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private EmployeeRepository _employeeRepository;
        public EmployeesViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            FillListView();
        }

        private string _filter; //данные из TextBox
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                FillListView();
            }
        }

        private ObservableCollection<Employee> _employees; //По функциональности коллекция ObservableCollection похожа на список List за тем
        //исключением, что позволяет известить внешние объекты о том, что коллекция была изменена (через делегат NotifyCollectionChangedEventHandler).
        public ObservableCollection<Employee> Employees
        {
            get 
            {
                return _employees;
            }
            set 
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        int countItems = default;

        ///<summary>
        ///Метод, который будет заполнять данными ListView
        ///<summary>
        protected void FillListView()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                Employees = new ObservableCollection<Employee>(_employeeRepository.GetAll().Where(v => v.LastName.Contains(_filter))); //если фильтр не пустой, мы получаем всех сотрудников из репозитория, а затем производим фильтрацию данных сотрудника при помощи Linq.
                countItems = Employees.Count();
            }
            else
            {
                Employees = new ObservableCollection<Employee>(_employeeRepository.GetAll());//если фильтр пустой, то мы получаем всех сотрудников из репозитория;
            }
        }


    }
}
