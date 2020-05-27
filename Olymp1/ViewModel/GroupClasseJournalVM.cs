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
    public class GroupClasseJournalVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public GroupClasseJournalVM()
        {
            Dt1 = DateTime.Now;
            Dt2 = Dt1.AddDays(7);
            GroupClassesJournal = dc.GroupClassesJournals.Where(x => x.ClassesTime > Dt1 && x.ClassesTime < Dt2).ToList();
        }

        private List<GroupClassesJournal> groupClassesJournal;
        public List<GroupClassesJournal> GroupClassesJournal
        {
            get { return groupClassesJournal; }
            set
            {
                groupClassesJournal = value;
                OnPropertyChanged("GroupClassesJournal");
            }
        }


        private GroupClassesJournal selectedgroupClasseJournal;
        public GroupClassesJournal SelectedGroupClasseJournal
        {
            get { return selectedgroupClasseJournal; }
            set
            {
                selectedgroupClasseJournal = value;
                OnPropertyChanged("SelectedGroupClasseJournal");
            }
        }

        private DateTime dt1;
        public DateTime Dt1
        {
            get { return dt1; }
            set
            {
                dt1 = value;
                GroupClassesJournal = dc.GroupClassesJournals.Where(x => x.ClassesTime > value && x.ClassesTime < Dt2).ToList();
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
                GroupClassesJournal = dc.GroupClassesJournals.Where(x => x.ClassesTime > Dt1 && x.ClassesTime < value).ToList();
                OnPropertyChanged("Dt2");
            }
        }

        private CommandBase addGroupClasse;
        public CommandBase AddGroupClasse
        {
            get
            {
                return addGroupClasse ??
                    (addGroupClasse = new CommandBase(obj =>
                    {
                        SelectedGroupClasseJournal = null;
                        GroupClassesJournalEditForm journalEdit = new GroupClassesJournalEditForm(SelectedGroupClasseJournal);
                        journalEdit.Show();
                    }));
            }
        }

        private CommandBase editGroupClasse;
        public CommandBase EditGroupClasse
        {
            get
            {
                return editGroupClasse ??
                    (editGroupClasse = new CommandBase(obj =>
                    {
                        if (SelectedGroupClasseJournal is null)
                            SelectedGroupClasseJournal = GroupClassesJournal.First();
                        GroupClassesJournalEditForm journalEdit = new GroupClassesJournalEditForm(SelectedGroupClasseJournal);
                        journalEdit.Show();
                    }));
            }
        }

        private CommandBase deleteGroupClasse;
        public CommandBase DeleteGroupClasse
        {
            get
            {
                return deleteGroupClasse ??
                    (deleteGroupClasse = new CommandBase(obj =>
                    {
                        if (SelectedGroupClasseJournal is null)
                            SelectedGroupClasseJournal = GroupClassesJournal.First();
                        dc.GroupClassesJournals.Remove(SelectedGroupClasseJournal);
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
