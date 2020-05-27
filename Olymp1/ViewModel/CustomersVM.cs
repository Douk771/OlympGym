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
    public class CustomersVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public CustomersVM()
        {
            Customers = dc.Customers.ToList();
            
        }

        private List<Customer> customers;
        public List<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged("Customers");
            }
        }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        private CommandBase addCustomer;
        public CommandBase AddCustomer
        {
            get
            {
                return addCustomer ??
                    (addCustomer = new CommandBase(obj =>
                    {
                        SelectedCustomer = null;
                        CustomerEditForm customerEditForm = new CustomerEditForm(SelectedCustomer);
                        customerEditForm.Show();

                    }));
            }
        }

        private CommandBase editCustomer;
        public CommandBase EditCustomer
        {
            get
            {
                return editCustomer ??
                    (editCustomer = new CommandBase(obj =>
                    {
                        if (SelectedCustomer is null)
                            SelectedCustomer = Customers.First();
                        CustomerEditForm customerEditForm = new CustomerEditForm(SelectedCustomer);
                        customerEditForm.Show();
                    }));
            }
        }

        private CommandBase deleteCustomer;
        public CommandBase DeleteCustomer
        {
            get
            {
                return deleteCustomer ??
                    (deleteCustomer = new CommandBase(obj =>
                    {
                        if (SelectedCustomer is null)
                            SelectedCustomer = Customers.First();
                        dc.Customers.Remove(SelectedCustomer);
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
