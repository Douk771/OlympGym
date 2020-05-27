using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1.ViewModel
{
    public class VisitLogVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public VisitLogVM()
        {
            Dt2 = DateTime.Now.AddDays(1);
            Dt1 = Dt2.AddDays(-7);
            Visits = dc.VisitLogs.Where(x => x.BeginDate > Dt1 && x.BeginDate < Dt2).ToList();

        }

        private List<VisitLog> visits;
        public List<VisitLog> Visits
        {
            get { return visits; }
            set
            {
                visits = value;
                OnPropertyChanged("Visits");
            }
        }

        private DateTime dt1;
        public DateTime Dt1
        {
            get { return dt1; }
            set
            {
                dt1 = value;
                //GroupClassesJournal = dc.GroupClassesJournals.Where(x => x.ClassesTime > value && x.ClassesTime < Dt2).ToList();
                OnPropertyChanged("Dt1");
            }
        }

        private DateTime dt2;
        public DateTime Dt2
        {
            get { return dt2; }
            set
            {
                dt2 = value;
                //GroupClassesJournal = dc.GroupClassesJournals.Where(x => x.ClassesTime > Dt1 && x.ClassesTime < value).ToList();
                OnPropertyChanged("Dt2");
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
