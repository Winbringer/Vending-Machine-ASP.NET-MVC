using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_ASP_MVC.Models
{
    public class Change
    {
        public int Id { get; set; }
        public virtual List<Coin> Coins { get; set; }
    }
}
