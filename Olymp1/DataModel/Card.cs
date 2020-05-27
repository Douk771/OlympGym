using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public DateTime DeactivationDate { get; set; }

        
        public virtual Customer Customer { get; set; }

        public virtual List<VisitLog> VisitLogs { get; set; }

    }
}
