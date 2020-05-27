using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1.ViewModel.EditFormsVM
{
    public class CardEditFormVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public Action CloseAction { get; set; }

        public CardEditFormVM(Card card)
        {
            Msg = "";
            if (card != null)
                SelectedCard = dc.Cards.Where(x => x.CardId == card.CardId).First();
            else
            {
                SelectedCard = new Card();
                SelectedCard.DeactivationDate = DateTime.Now.AddMonths(6);
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

        private CommandBase saveCard;
        public CommandBase SaveCard
        {
            get
            {
                return saveCard ??
                    (saveCard = new CommandBase(obj =>
                    {
                        if (SelectedCard.Name != null && SelectedCard.Name != "")
                        {
                            if (SelectedCard.CardId == 0)
                            {
                                dc.Cards.Add(SelectedCard);
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
