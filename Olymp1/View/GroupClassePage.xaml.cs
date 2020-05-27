﻿using Olymp1.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olymp1.View
{
    /// <summary>
    /// Логика взаимодействия для GroupClassePage.xaml
    /// </summary>
    public partial class GroupClassePage : Page
    {
        public GroupClassePage()
        {
            InitializeComponent();
            DataContext = new GroupClasseVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new GroupClasseVM();

        }
    }
}
