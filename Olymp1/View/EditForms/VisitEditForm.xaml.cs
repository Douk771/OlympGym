using Olymp1.ViewModel;
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
    /// Логика взаимодействия для VisitEditForm.xaml
    /// </summary>
    public partial class VisitEditForm : Window
    {
        public VisitEditForm(Booth booth)
        {
            InitializeComponent();
            VisitEditFormVM vm = new VisitEditFormVM(booth);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }
    }
}
