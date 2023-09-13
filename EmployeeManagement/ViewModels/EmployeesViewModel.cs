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
            TextBlockResult();
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
                TextBlockResult();
            }
        }

        private ObservableCollection<Employee> _employees; //По функциональности коллекция ObservableCollection похожа на список List за тем
        //исключением, что позволяет известить внешние объекты о том, что коллекция была изменена (через делегат NotifyCollectionChangedEventHandler).
        public ObservableCollection<Employee> EmployeesObserve
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

        public int countItems = default;

        ///<summary>
        ///Метод, который будет заполнять данными ListView
        ///<summary>
        protected void FillListView()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                EmployeesObserve = new ObservableCollection<Employee>(_employeeRepository.GetAll().Where(v => v.LastName.Contains(_filter))); //если фильтр не пустой, мы получаем всех сотрудников из репозитория, а затем производим фильтрацию данных сотрудника при помощи Linq.
                countItems = EmployeesObserve.Count();
            }
            else
            {
                EmployeesObserve = new ObservableCollection<Employee>(_employeeRepository.GetAll());//если фильтр пустой, то мы получаем всех сотрудников из репозитория;
            }
        }

        #region Блок для вывода информации в TextBlock1
        private string _textBlock1;
        public string TextBlock1 
        {
            get
            {
                return _textBlock1;
            }
            set
            {
                _textBlock1 = value;
                OnPropertyChanged();
            }
        }
        public void TextBlockResult()
        {

            if (String.IsNullOrEmpty(Filter))
            {
                TextBlock1 = "<-Введите данные для поиска";
            }
            else
            {
                TextBlock1 = $"По вашему запросу найдено {EmployeesObserve.Count()} человек.";
            }
        }
        #endregion
    }
}
