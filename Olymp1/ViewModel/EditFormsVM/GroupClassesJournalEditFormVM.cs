using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1.ViewModel.EditFormsVM
{
    public class GroupClassesJournalEditFormVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public Action CloseAction { get; set; }

        public GroupClassesJournalEditFormVM(GroupClassesJournal groupClassesJournal)
        {
            Msg = "";
            

            if (groupClassesJournal != null)
            {
                SelectedGroupClassesJournal = dc.GroupClassesJournals
                    .Where(x => x.GroupClasseId == groupClassesJournal.GroupClasseId).First();
                SelectedClassesTime = SelectedGroupClassesJournal.ClassesTime;
            }
            else
            {
                SelectedGroupClassesJournal = new GroupClassesJournal();
                SelectedClassesTime = DateTime.Now;
            }
            HH = SelectedClassesTime.Hour;
            MM = SelectedClassesTime.Minute;
            Employees = dc.Employees.Where(x=>x.Position.PositionId ==2).ToList();
            GroupClasses = dc.GroupClasses.ToList();
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

        private List<GroupClasse> groupClasses;
        public List<GroupClasse> GroupClasses
        {
            get { return groupClasses; }
            set
            {
                groupClasses = value;
                OnPropertyChanged("GroupClasses");
            }
        }

        private GroupClassesJournal selectedGroupClassesJournal;
        public GroupClassesJournal SelectedGroupClassesJournal
        {
            get { return selectedGroupClassesJournal; }
            set
            {
                selectedGroupClassesJournal = value;
                OnPropertyChanged("SelectedGroupClassesJournal");
            }
        }

        private DateTime selectedClassesTime;
        public DateTime SelectedClassesTime
        {
            get { return selectedClassesTime; }
            set
            {
                selectedClassesTime = value;
                OnPropertyChanged("SelectedClassesTime");
            }
        }

        private int mm;
        public int MM
        {
            get { return mm; }
            set
            {
                mm = value;
                OnPropertyChanged("MM");
            }
        }

        private int hh;
        public int HH
        {
            get { return hh; }
            set
            {
                hh = value;
                OnPropertyChanged("HH");
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





        private CommandBase saveClassJournal;
        public CommandBase SaveClassJournal
        {
            get
            {
                return saveClassJournal ??
                    (saveClassJournal = new CommandBase(obj =>
                    {
                        if (true/*SelectedGroupClassesJournal.FIO != null && SelectedGroupClassesJournal.FIO != ""
                               && SelectedGroupClassesJournal.PhoneNumber != null && SelectedGroupClassesJournal.PhoneNumber != ""*/)
                        {
                            if (SelectedGroupClassesJournal.ClassesId == 0)
                            {
                                SelectedGroupClassesJournal.ClassesTime = new DateTime(SelectedClassesTime.Year
                                    , SelectedClassesTime.Month, SelectedClassesTime.Day, Convert.ToInt32(HH) > 19 ? 19 : Convert.ToInt32(HH)
                                    , Convert.ToInt32(MM) > 59 ? 0 : Convert.ToInt32(MM), 0);
                                dc.GroupClassesJournals.Add(SelectedGroupClassesJournal);
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
