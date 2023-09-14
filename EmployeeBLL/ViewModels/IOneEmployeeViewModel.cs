using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLL.ViewModels
{
    public interface IOneEmployeeViewModel
    {
        Employee Employee { get; set; }
    }
}
