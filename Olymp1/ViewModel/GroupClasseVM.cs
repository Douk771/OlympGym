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
    public class GroupClasseVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public GroupClasseVM()
        {
            GroupClasses = dc.GroupClasses.ToList();
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


        private GroupClasse selectedgroupClasse;
        public GroupClasse SelectedGroupClasse
        {
            get { return selectedgroupClasse; }
            set
            {
                selectedgroupClasse = value;
                OnPropertyChanged("SelectedGroupClasse");
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
                        SelectedGroupClasse = null;
                        GroupClasseEditForm cardEditForm = new GroupClasseEditForm(SelectedGroupClasse);
                        cardEditForm.Show();
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
                        if (SelectedGroupClasse is null)
                            SelectedGroupClasse = GroupClasses.First();
                        GroupClasseEditForm groupClasseEditForm = new GroupClasseEditForm(SelectedGroupClasse);
                        groupClasseEditForm.Show();
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
                        if (SelectedGroupClasse is null)
                            SelectedGroupClasse = GroupClasses.First();
                        dc.GroupClasses.Remove(SelectedGroupClasse);
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
