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
    /// Логика взаимодействия для CardEditForm.xaml
    /// </summary>
    public partial class CardEditForm : Window
    {
        public CardEditForm(Card card)
        {
            InitializeComponent();
            CardEditFormVM vm = new CardEditFormVM(card);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
