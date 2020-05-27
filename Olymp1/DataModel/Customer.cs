using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olymp1
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [MaxLength(250), Required]
        public string FIO { get; set; }

        [MaxLength(12), Required]
        public string PhoneNumber { get; set; }

        [Required]
        public virtual  Card Card { get; set; }

    }
}
