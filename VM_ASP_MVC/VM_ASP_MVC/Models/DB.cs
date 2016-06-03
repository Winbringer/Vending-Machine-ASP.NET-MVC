using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;

namespace VM_ASP_MVC.Models
{
    class DB : DbContext
    {
        public DbSet<Purse> Putses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<Coin> Coins { get; set; }
    }
}
