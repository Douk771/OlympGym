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
    public class CardsVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public CardsVM()
        {
            Cards = dc.Cards.ToList();
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


        private Card selectedCard;
        public Card SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
                OnPropertyChanged("SelectedCard");
            }
        }

        private CommandBase addCard;
        public CommandBase AddCard
        {
            get
            {
                return addCard ??
                    (addCard = new CommandBase(obj =>
                    {
                        SelectedCard = null;
                        CardEditForm cardEditForm = new CardEditForm(SelectedCard);
                        cardEditForm.Show();
                    }));
            }
        }

        private CommandBase editCard;
        public CommandBase EditCard
        {
            get
            {
                return editCard ??
                    (editCard = new CommandBase(obj =>
                    {
                        if (SelectedCard is null)
                            SelectedCard = Cards.First();
                        CardEditForm cardEditForm = new CardEditForm(SelectedCard);
                        cardEditForm.Show();
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
                        if (SelectedCard is null)
                            SelectedCard = Cards.First();
                        dc.Cards.Remove(SelectedCard);
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
