using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1
{
    public class VisitLog
    {
        [Key]
        public int VisitId { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int BoothNumber { get; set; }

        public int CardId { get; set; }

        public virtual Card Card { get; set; }

    }
}
