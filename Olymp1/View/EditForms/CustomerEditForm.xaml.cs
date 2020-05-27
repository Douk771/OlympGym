using Olymp1.ViewModel.EditFormsVM;
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
    /// Логика взаимодействия для CustomerEditForm.xaml
    /// </summary>
    public partial class CustomerEditForm : Window
    {
        public CustomerEditForm(Customer customer)
        {
            InitializeComponent();
            CustomerEditFormVM vm = new CustomerEditFormVM(customer);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
