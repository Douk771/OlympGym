using Olymp1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1
{
    class AuthorizationViewModel : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private string error;

        public GymContext dc = new GymContext();
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged("Error");
            }
        }


        /*
         Employee employee = dc.Employees.Where(x => x.Login == login.Text && x.Password == pas.Password).First();
            if (employee != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
             */
        private CommandBase addCommand;
        public CommandBase AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new CommandBase(obj =>
                    {
                        Employee employee = dc.Employees.Where(x => x.Login == login && x.Password == password).First();
                        if (employee != null)
                        {
                            Error = "ffefe";
                        }
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
