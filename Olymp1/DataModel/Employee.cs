using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [MaxLength(250), Required]
        public string FIO { get; set; }

        [MaxLength(50), Required]
        public string Login { get; set; }

        [MaxLength(50), Required]
        public string Password { get; set; }


        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public virtual List<GroupClassesJournal> GroupClassesJournals { get; set; }
    }
}
