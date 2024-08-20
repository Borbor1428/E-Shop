using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Context;
using EmptyLayer.Entities;
using PagedList;

namespace E_Shop.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        DataContext db = new DataContext();
        public ActionResult Index(int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;
                var user = db.Users.FirstOrDefault(x => x.Mail == username);
                var model = db.Sales.Where(x => x.UserId == user.UserId).ToList().ToPagedList(page, 5);
                return View(model);
            }
            return HttpNotFound();
        }
        public ActionResult Buy(int id)
        {
            var model = db.Cards.FirstOrDefault(x => x.Id == id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Purchase(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = db.Cards.FirstOrDefault(x => x.Id == id);

                    var sales = new Sales
                    {
                        UserId = model.UserId,
                        ProductId = model.ProductId,
                        Quantity = model.Quantity,
                        Image = model.Image,
                        price = model.price,
                        Date = model.Date,

                    };
                    db.Cards.Remove(model);
                    db.Sales.Add(sales);
                    db.SaveChanges();
                    ViewBag.islem = "Satın Alma İşlemi Başarılı Bir Şekilde Gerçekleşmiştir";
                }
            }
            catch (Exception)
            {

                ViewBag.islem = "Satın Alma İşlemi Başarısız ";
            }

            return View("Process");

        }
        public ActionResult BuyAll(decimal? cost)
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;
                var user = db.Users.FirstOrDefault(x => x.Mail == username);
                var model = db.Cards.Where(x => x.UserId == user.UserId).ToList();
                var kid = db.Cards.FirstOrDefault(x => x.UserId == user.UserId);
                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmamaktadır";
                    }
                    else if (kid != null)
                    {
                        cost = db.Cards.Where(x => x.UserId == kid.UserId).Sum(x => x.Product.Price * x.Quantity);
                        ViewBag.Tutar = "Toplam Tutar = " + cost + "TL";
                    }
                    return View(model);
                }

                return View();
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult PurchaseAll()
        {
            var username = User.Identity.Name;
            var user = db.Users.FirstOrDefault(x => x.Mail == username);
            var model = db.Cards.Where(x => x.UserId == user.UserId).ToList();
            int row = 0;
            foreach (var item in model)
            {
                var sales = new Sales
                {
                    UserId = model[row].UserId,
                    ProductId = model[row].ProductId,
                    Quantity = model[row].Quantity,
                    price = model[row].price,
                    Image = model[row].Product.Image,
                    Date = DateTime.Now
                };
                db.Sales.Add(sales);
                db.SaveChanges();
                row++;
            }
            db.Cards.RemoveRange(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
    }
}