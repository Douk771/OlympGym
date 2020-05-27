using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1
{
    public class GroupClassesJournal
    {
        [Key]
        public int ClassesId { get; set; }

        [Required]
        public DateTime ClassesTime { get; set; }

        
        public int EmployeeId { get; set; }

        public int GroupClasseId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual GroupClasse GroupClasse { get; set; }
    }
}
