using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
