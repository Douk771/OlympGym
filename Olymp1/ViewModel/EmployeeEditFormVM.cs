using Olymp1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olymp1
{
    public class EmployeeEditFormVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public Action CloseAction { get; set; }

        public EmployeeEditFormVM(Employee employee)
        {
            Msg = "";
            if (employee != null)
                SelectedEmployee = dc.Employees.Where(x => x.EmployeeId == employee.EmployeeId).First();
            else
                SelectedEmployee = new Employee();
            Positions = dc.Positions.ToList();
        }


        private List<Position> positions;
        public List<Position> Positions
        {
            get { return positions; }
            set
            {
                positions = value;
                OnPropertyChanged("Positions");
            }
        }

        private string msg;
        public string Msg
        {
            get { return msg; }
            set
            {
                msg = value;
                OnPropertyChanged("Msg");
            }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        private CommandBase saveEmployee;
        public CommandBase SaveEmployee
        {
            get
            {
                return saveEmployee ??
                    (saveEmployee = new CommandBase(obj =>
                    {
                        if (SelectedEmployee.FIO != null && SelectedEmployee.FIO != ""
                            && SelectedEmployee.Login != null && SelectedEmployee.Login != ""
                            && SelectedEmployee.Password != null && SelectedEmployee.Password != ""
                            && SelectedEmployee.PositionId != 0)
                        {
                            if (SelectedEmployee.EmployeeId == 0)
                            {
                                dc.Employees.Add(SelectedEmployee);
                                dc.SaveChanges();
                                CloseAction();
                            }
                            else
                            {
                                dc.SaveChanges();
                                CloseAction();
                            }
                        }
                        else
                        {
                            Msg = "Заполните все поля!";
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
