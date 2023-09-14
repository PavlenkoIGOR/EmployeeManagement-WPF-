using EmployeeBLL.ViewModels;
using EmployeeManagement.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для OneEmployeeView.xaml
    /// </summary>
    public partial class OneEmployeeView : Window
    {
        public OneEmployeeView(IOneEmployeeViewModel viewModel)//внедрение зависимости
        {
            InitializeComponent();
            DataContext = viewModel; //установка контекста данных
        }
    }
}
