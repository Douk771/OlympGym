using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1
{
    public class GroupClasse
    {
        public int GroupClasseId { get; set; }

        [MaxLength(50),Required]
        public string GroupClasseName { get; set; }

        public virtual List<GroupClassesJournal> GroupClassesJournals { get; set; }
    }
}
