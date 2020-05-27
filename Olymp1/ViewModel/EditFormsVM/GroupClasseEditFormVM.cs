using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1.ViewModel.EditFormsVM
{
    public class GroupClasseEditFormVM : INotifyPropertyChanged
    {
        public GymContext dc = new GymContext();

        public Action CloseAction { get; set; }
        public Action UpdateContext { get; set; }


        public GroupClasseEditFormVM(GroupClasse groupClasse)
        {
            Msg = "";
            if (groupClasse != null)
                SelectedGroupClasse = dc.GroupClasses.Where(x => x.GroupClasseId == groupClasse.GroupClasseId).First();
            else
                SelectedGroupClasse = new GroupClasse();

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

        private GroupClasse selectedGroupClasse;
        public GroupClasse SelectedGroupClasse
        {
            get { return selectedGroupClasse; }
            set
            {
                selectedGroupClasse = value;
                OnPropertyChanged("SelectedGroupClasse");
            }
        }

        private CommandBase saveGroupClasse;
        public CommandBase SaveGroupClasse
        {
            get
            {
                return saveGroupClasse ??
                    (saveGroupClasse = new CommandBase(obj =>
                    {
                        if (true/*SelectedGroupClassesJournal. != null && SelectedGroupClassesJournal.GroupClasseName != ""*/)
                        {
                            if (SelectedGroupClasse.GroupClasseId == 0)
                            {
                                dc.GroupClasses.Add(SelectedGroupClasse);
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
