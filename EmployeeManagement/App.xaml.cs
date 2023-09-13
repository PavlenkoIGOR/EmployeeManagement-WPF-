//using EmployeeBLL.Models;
//using EmployeeBLL.ViewModels;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using EmployeeManagement.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>(); //добавление в container наши репозиториев
            container.RegisterType<IEmployeesViewModel, EmployeesViewModel>(); //добавление в container наши репозиториев
            container.RegisterType<ILogger, Logger>(); //добавление в container наши репозиториев

            container.Resolve<EmployeesView>().Show(); //запуск вручную нужной нам вьюшки и после такого запуска из App.xaml 
                                                       //удалить строку запуска нужного окна (StartupUri="Views/EmployeesView.xaml"), а так же удалить из
                                                       //"EmployeesView.xaml" <Window.DataContext><vm:EmployeesViewModel></vm:EmployeesViewModel></Window.DataContext>.
        }
    }
}
