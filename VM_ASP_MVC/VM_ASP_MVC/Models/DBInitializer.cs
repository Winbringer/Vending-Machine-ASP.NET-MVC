
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VM_ASP_MVC.Models
{
    class DBInitializer : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB db)
        {
            db.Products.Add(new Product { ProductName = "Чай", Price = 13m, Count = 10 });
            db.Products.Add(new Product { ProductName = "Кофе", Price = 18m, Count = 20 });
            db.Products.Add(new Product { ProductName = "Кофе с молоком", Price = 21m, Count = 20 });
            db.Products.Add(new Product { ProductName = "Сок", Price = 35m, Count = 15 });

            db.Changes.Add(new Change
            {
                Coins = new List<Coin>
                { new Coin { Name ="руб",
                 Value=1,
                    Count =100},new Coin { Name ="руб",
                 Value=2,
                    Count =100},new Coin { Name ="руб",
                 Value=5,
                    Count =100},new Coin { Name ="руб",
                 Value=10,
                    Count =100}
                }
            });

            db.Putses.Add(new Purse
            {
                Sum = 0,
                Coins = new List<Coin>
                { new Coin { Name ="руб",
                 Value=1,
                    Count =10},new Coin { Name ="руб",
                 Value=2,
                    Count =20},new Coin { Name ="руб",
                 Value=5,
                    Count =30},new Coin { Name ="руб",
                 Value=10,
                    Count =15}
                }
            });

            base.Seed(db);
        }
    }
}