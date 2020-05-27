using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Olymp1.ViewModel.EditFormsVM
{
    public class VisitEditFormVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public Action CloseAction { get; set; }

        public VisitEditFormVM(Booth booth)
        {
            Msg = "";
            if (booth.Background == Brushes.Yellow)
            {
                VisitLog = dc.VisitLogs.Where(x => x.BoothNumber == booth.Number && x.EndDate == null).First();
                VisitLog.EndDate = DateTime.Now;
                CardId = VisitLog.CardId;
                CardFill = false;
            }
            else
            {
                VisitLog = new VisitLog { BoothNumber = booth.Number, BeginDate = DateTime.Now };
                CardFill = true;
            }
        }

        private int cardId;
        public int CardId
        {
            get { return cardId; }
            set
            {
                cardId = value;
                OnPropertyChanged("CardId");
            }
        }

        private bool cardFill;
        public bool CardFill
        {
            get { return cardFill; }
            set
            {
                cardFill = value;
                OnPropertyChanged("CardFill");
            }
        }


        private VisitLog  visitLog;
        public VisitLog VisitLog
        {
            get { return visitLog; }
            set
            {
                visitLog = value;
                OnPropertyChanged("VisitLog");
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

        private CommandBase saveVisit;
        public CommandBase SaveVisit
        {
            get
            {
                return saveVisit ??
                    (saveVisit = new CommandBase(obj =>
                    {
                        if(CardId != 0)
                            if (VisitLog.CardId == 0)
                            {
                                if (dc.Cards.Any(x => x.CardId == CardId))
                                {
                                    VisitLog.Card = dc.Cards.Where(x => x.CardId == CardId).First();
                                    dc.VisitLogs.Add(VisitLog);
                                    dc.SaveChanges();
                                    CloseAction();
                                }
                                else
                                    Msg = "Владелец у данной карты отсутствует. Введите другой код!";
                            }
                            else
                            {
                                dc.SaveChanges();
                                CloseAction();
                            }
                       else
                          Msg = "Заполните номер карты!";
                        

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
