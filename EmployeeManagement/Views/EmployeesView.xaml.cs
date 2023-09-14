using EmployeeBLL.ViewModels;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeManagement.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : Window
    {
        IEmployeesViewModel _viewModel;
        IOneEmployeeViewModel _oneEmployeeViewModel;
        public EmployeesView(IEmployeesViewModel employeesViewModel, IOneEmployeeViewModel oneEmployeeViewModel)
        {
            _viewModel = employeesViewModel;
            _oneEmployeeViewModel = oneEmployeeViewModel;
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void ListView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem; //получаем объект "ListView" и обращаемся к его свойству "SelectedItem".
            if (item is null) //проверка на "null"
            {
                return;
            }
            Employee employee = item as Employee;//в противном случае отобразится сообщение с информацией о сотруднике.
            
            //MessageBox.Show($"{employee.FirstName} {employee.LastName} {employee.Age} лет {Environment.NewLine} Место работы: {employee.CompanyName}{Environment.NewLine}Должность: {employee.Position}{Environment.NewLine}Город: {employee.CityName}");
            //далее метод запуска окошка с данными пользователями вместо обычного Message.Sho():
            _oneEmployeeViewModel.Employee = employee;
            OneEmployeeView oneEmployee = new OneEmployeeView(_oneEmployeeViewModel);
            oneEmployee.Show();
        }
        private void ShowQ()
        {

        }
    }
}
