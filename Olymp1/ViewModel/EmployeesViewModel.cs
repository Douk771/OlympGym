using Olymp1.View.EditForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1.ViewModel
{
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public EmployeesViewModel()
        {
            Employees = dc.Employees.ToList();
        }

        private List<Employee> employees;
        public List<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
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

        private CommandBase addEmployee;
        public CommandBase AddEmployee
        {
            get
            {
                return addEmployee ??
                    (addEmployee = new CommandBase(obj =>
                    {
                        SelectedEmployee = null;
                        EmployeeEditForm employeeEditForm = new EmployeeEditForm(SelectedEmployee);
                        employeeEditForm.Show();

                    }));
            }
        }

        private CommandBase editEmployee;
        public CommandBase EditEmployee
        {
            get
            {
                return editEmployee ??
                    (editEmployee = new CommandBase(obj =>
                    {
                        if (SelectedEmployee is null)
                            SelectedEmployee = Employees.First();
                        EmployeeEditForm employeeEditForm = new EmployeeEditForm(SelectedEmployee);
                        employeeEditForm.Show();
                    }));
            }
        }

        private CommandBase deleteEmployee;
        public CommandBase DeleteEmployee
        {
            get
            {
                return deleteEmployee ??
                    (deleteEmployee = new CommandBase(obj =>
                    {
                        if (SelectedEmployee is null)
                            SelectedEmployee = Employees.First();
                        dc.Employees.Remove(SelectedEmployee);
                        dc.SaveChanges();
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
