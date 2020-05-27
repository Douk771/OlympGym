using Olymp1.View;
using Olymp1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Olymp1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Page Main;


        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private double frameOpacity;
        public double FrameOpacity
        {
            get { return frameOpacity; }
            set
            {
                frameOpacity = value;
                OnPropertyChanged("FrameOpacity");
            }
        }

        public MainViewModel()
        {
            Main = new MainPage();
            FrameOpacity = 1;
            CurrentPage = Main;
        }

        private CommandBase cardCmd;
        public CommandBase CardCmd
        {
            get
            {
                return cardCmd ??
                    (cardCmd = new CommandBase(obj =>
                    {
                        CurrentPage = new CardsPage();
                    }));
            }
        }

        private CommandBase customerCmd;
        public CommandBase CustomerCmd
        {
            get
            {
                return customerCmd ??
                    (customerCmd = new CommandBase(obj =>
                    {
                        CurrentPage = new CustomersPage();
                    }));
            }
        }

        private CommandBase employeeCmd;
        public CommandBase EmployeeCmd
        {
            get
            {
                return employeeCmd ??
                    (employeeCmd = new CommandBase(obj =>
                    {
                        CurrentPage = new Employees(); 
                    }));
            }
        }

        private CommandBase groupClasseCmd;
        public CommandBase GroupClasseCmd
        {
            get
            {
                return groupClasseCmd ??
                    (groupClasseCmd = new CommandBase(obj =>
                    {
                        CurrentPage = new GroupClassePage();
                    }));
            }
        }

        private CommandBase groupClasseJournalCmd;
        public CommandBase GroupClasseJournalCmd
        {
            get
            {
                return groupClasseJournalCmd ??
                    (groupClasseJournalCmd = new CommandBase(obj =>
                    {
                        CurrentPage = new GroupClasseJournalPage();
                    }));
            }
        }

        private CommandBase mainCmd;
        public CommandBase MainCmd
        {
            get
            {
                return mainCmd ??
                    (mainCmd = new CommandBase(obj =>
                    {
                        CurrentPage = new MainPage();
                    }));
            }
        }

        private CommandBase visitCmd;
        public CommandBase VisitCmd
        {
            get
            {
                return visitCmd ??
                    (visitCmd = new CommandBase(obj =>
                    {
                        CurrentPage = new VisitsPage();
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
