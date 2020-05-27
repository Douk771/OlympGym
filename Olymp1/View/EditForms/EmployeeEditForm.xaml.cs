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

namespace Olymp1.View.EditForms
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEditForm.xaml
    /// </summary>
    public partial class EmployeeEditForm : Window
    {
        public EmployeeEditForm(Employee employee)
        {
            InitializeComponent();
            EmployeeEditFormVM vm = new EmployeeEditFormVM(employee);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
