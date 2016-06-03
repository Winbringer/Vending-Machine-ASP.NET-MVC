using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_ASP_MVC.Models
{
    public class Purse
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public List<Coin> Coins { get; set; }
    }
}
