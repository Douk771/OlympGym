using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1.ViewModel.EditFormsVM
{
    public class CustomerEditFormVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public Action CloseAction { get; set; }

        public CustomerEditFormVM(Customer customer)
        {
            Msg = "";

            if (customer != null)
            {
                SelectedCustomer = dc.Customers.Where(x => x.CustomerId == customer.CustomerId).First();
                Cards = dc.Cards.Where(x => x.Customer == null || x.Customer.CustomerId == SelectedCustomer.CustomerId).ToList();
                SelectedCard = SelectedCustomer.CustomerId;
            }
            else
            {
                SelectedCustomer = new Customer();
                Cards = dc.Cards.Where(x => x.Customer == null).ToList();
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

        private List<Card> cards;
        public List<Card> Cards
        {
            get { return cards; }
            set
            {
                cards = value;
                OnPropertyChanged("Cards");
            }
        }

        private int selectedCard;
        public int SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
                OnPropertyChanged("SelectedCard");
            }
        }

        private CommandBase saveCustomer;
        public CommandBase SaveCustomer
        {
            get
            {
                return saveCustomer ??
                    (saveCustomer = new CommandBase(obj =>
                    {
                        if (SelectedCustomer.FIO != null && SelectedCustomer.FIO != ""
                               && SelectedCustomer.PhoneNumber != null && SelectedCustomer.PhoneNumber != "")
                        {
                            if (SelectedCustomer.CustomerId == 0)
                            {
                                SelectedCustomer.CustomerId = SelectedCard;
                                dc.Customers.Add(SelectedCustomer);
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
                            Msg = "Заполните наименование!";
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