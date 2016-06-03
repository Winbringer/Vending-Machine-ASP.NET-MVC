using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_ASP_MVC.Models
{
    public class ViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public Purse Purses { get; set; }
        public Change Change { get; set; }
    }
}
