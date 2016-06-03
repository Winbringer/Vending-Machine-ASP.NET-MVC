using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM_ASP_MVC.Models;
using System.Data.Entity;
namespace VM_ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        DB db = new DB();

        public ActionResult Index()
        {
            var vm = new ViewModel
            {
                Products = db.Products,
                Purses = db.Putses.Include("Coins").First(),
                Change = db.Changes.Include("Coins").First()
            };

            return View(vm);
        }
        public ActionResult GetProduct(int Id, int purse)
        {
            try
            {
                var pu = db.Putses.FirstOrDefault(x => x.Id == purse);

                if (pu == null) throw new NullReferenceException("Такого кошелька нет в базе");

                var pr = db.Products.FirstOrDefault(x => x.Id == Id);

                if (pr == null) throw new NullReferenceException("Такого товара нет в базе");

                if (pu.Sum >= pr.Price)
                {
                    pu.Sum -= pr.Price;
                    db.SaveChanges();
                    TempData["msg"] = "<script>alert('Спасибо!');</script>";
                    return RedirectToAction("Index");
                }

                TempData["msg"] = "<script>alert('Недостаточно средств!');</script>";
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("ErrorView");
            }

        }

        public ActionResult AddCoin(int Id, int purse, int change)
        {
            try
            {
                var p = db.Putses.FirstOrDefault(x => x.Id == purse);
                if (p == null) throw new NullReferenceException("Не удалось найти такой кошелек в БД!");
                var c = db.Coins.FirstOrDefault(x => x.Id == Id);
                if (c == null) throw new NullReferenceException("Не удалось найти такой монеты в БД!");
                if (c.Count <= 0) throw new ArgumentException("У вас закончились монетки с таким номиналом!");
                var ch = db.Changes.Include("Coins").FirstOrDefault(x => x.Id == change);
                if (ch == null) throw new NullReferenceException("Не удалось найти такой кошелек VM машины в БД!");
                var coin = ch.Coins.FirstOrDefault(x => x.Value == c.Value);
                if (coin == null) throw new NullReferenceException("Не удалось найти такой монеты у VM!");
                coin.Count += 1;
                c.Count -= 1;
                p.Sum += c.Value;
                db.SaveChanges();

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("ErrorView");
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetChange(int Id, int change)
        {
            try
            {
                var p = db.Putses.Include("Coins").FirstOrDefault(x => x.Id == Id);

                if (p == null) throw new NullReferenceException("Не удалось найти такой кошелек в БД!");

                var c = db.Changes.Include("Coins").FirstOrDefault(x => x.Id == change);

                if (c == null) throw new NullReferenceException("Не удалось найти такой кошелек VM машины в БД!");
                decimal nominal = 50;
                while (p.Sum > 0)
                {
                    if (c.Coins.Any(x => x.Value == nominal) && p.Sum >= nominal)
                    {
                        c.Coins.Find(x => x.Value == nominal).Count -= 1;
                        p.Coins.Find(x => x.Value == nominal).Count += 1;

                        p.Sum -= nominal;
                        continue;
                    }
                    --nominal;
                }

                db.SaveChanges();

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("ErrorView");
            }

            return RedirectToAction("Index");
        }
    }
}