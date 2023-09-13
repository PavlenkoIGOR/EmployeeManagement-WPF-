using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public interface IEmployeesViewModel
    {
        ObservableCollection<Employee> EmployeesObserve { get; set; }
        string Filter { get; set; }
        string TextBlock1 { get; set; }
    }
}
