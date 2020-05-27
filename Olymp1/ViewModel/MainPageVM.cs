using Olymp1.View.EditForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Olymp1.ViewModel
{
    class MainPageVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public MainPageVM()
        {
            BoothsMen = new List<Booth>();
            BoothsWoomen = new List<Booth>();
            VisitLogs = dc.VisitLogs.Where(x => x.EndDate == null).ToList();

            for (int i = 1; i < 101; i++)
            {
                if (VisitLogs.Any(x => x.BoothNumber == i))
                    BoothsMen.Add(new Booth { Number = i, Background = Brushes.Yellow });
                else
                    BoothsMen.Add(new Booth { Number = i, Background = Brushes.Green });
            }
            for (int i = 101; i < 201; i++)
            {
                if (VisitLogs.Any(x => x.BoothNumber == i))
                    BoothsWoomen.Add(new Booth { Number = i, Background = Brushes.Yellow });
                else
                    BoothsWoomen.Add(new Booth { Number = i, Background = Brushes.Green });
            }
        }

        private List<VisitLog> visitLogs;
        public List<VisitLog> VisitLogs
        {
            get { return visitLogs; }
            set
            {
                visitLogs = value;
                OnPropertyChanged("VisitLogs");
            }
        }

        private List<Booth> boothsMen;
        public List<Booth> BoothsMen
        {
            get { return boothsMen; }
            set
            {
                boothsMen = value;
                OnPropertyChanged("BoothsMen");
            }
        }

        private List<Booth> boothsWoomen;
        public List<Booth> BoothsWoomen
        {
            get { return boothsWoomen; }
            set
            {
                boothsWoomen = value;
                OnPropertyChanged("BoothsWoomen");
            }
        }

        private Booth selecteBooth;
        public Booth SelectedBooth
        {
            get { return selecteBooth; }
            set
            {
                selecteBooth = value;
                OnPropertyChanged("Booth");
            }
        }

        
        private CommandBase addVisitCmd;
        public CommandBase AddVisitCmd
        {
            get
            {
                return addVisitCmd ??
                    (addVisitCmd = new CommandBase(obj =>
                    {
                        Booth booth = (int)obj < 101 ? BoothsMen.Where(x => x.Number == (int)obj).First() : BoothsWoomen.Where(x => x.Number == (int)obj).First();
                        VisitEditForm visitEditForm = new VisitEditForm(booth);
                        visitEditForm.Show();
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

    public class Booth
    {
        public int Number { get; set; }
        public Brush Background { get; set; }
    }

}
