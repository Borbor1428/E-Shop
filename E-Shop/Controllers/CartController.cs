using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Context;
using EmptyLayer.Entities;

namespace E_Shop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        DataContext db = new DataContext();
        public ActionResult Index(Decimal? cost)
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
                        ViewBag.Tutar = "Toplam Tutar =" + cost + "TL";
                    }
                    return View(model);
                }
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult AddCart(int id)
        {
            if (User.Identity.IsAuthenticated)
            {

                var UserName = User.Identity.Name;
                var model = db.Users.FirstOrDefault(x => x.Mail == UserName);
                var u = db.Products.Find(id);
                var Card = db.Cards.FirstOrDefault(x => x.UserId == model.UserId && x.ProductId == id);
                if (Session["userid"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    if (model != null)
                {
                    if (Session["userid"].ToString() == model.UserId.ToString())
                    {
                        if (Card != null)
                        {
                            Card.Quantity++;
                            Card.price = u.Price * Card.Quantity;
                            db.SaveChanges();
                            return RedirectToAction("Index", "Cart");
                        }
                        var s = new Card
                        {
                            UserId = model.UserId,
                            ProductId = u.Id,
                            Quantity = 1,
                            price = u.Price,
                            Date = DateTime.Now


                        };
                        db.Cards.Add(s);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Cart");
                    }
                   }
                return View();
               }


            }
            return HttpNotFound();
        }
        public ActionResult TotalCount(int? count)
        {
            if (User.Identity.IsAuthenticated)
            {

                var model = db.Users.FirstOrDefault(x => x.Mail == User.Identity.Name);
                count = db.Cards.Where(x => x.UserId == model.UserId).Count();
                ViewBag.Count = count;
                if (count == 0)
                {
                    ViewBag.Count = "";
                }

                return PartialView();
            }
            return HttpNotFound();
        }
        public ActionResult Increases(int id)
        {
            var model = db.Cards.Find(id);
            model.Quantity++;
            model.price = model.price * model.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult Lower(int id)
        {
            var model = db.Cards.Find(id);
            if (model.Quantity == 1)
            {
                db.Cards.Remove(model);
                db.SaveChanges();
            }
            model.Quantity--;
            model.price = model.price * model.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
        public void DynamicQuantity(int id, int quantity)
        {
            var model = db.Cards.Find(id);
            model.Quantity = quantity;
            model.price = model.price * model.Quantity;
            db.SaveChanges();

        }

        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = db.Users.FirstOrDefault(x => x.Mail == User.Identity.Name);
                if (Session["userid"].ToString() == model.UserId.ToString())
                {
                    var delete = db.Cards.Find(id);
                    db.Cards.Remove(delete);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Cart");
                }
            }
            return View();

        }

        public ActionResult DeleteRange()
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;
                var model = db.Users.FirstOrDefault(x => x.Mail == username);
                var delete = db.Cards.Where(x => x.UserId == model.UserId);
                db.Cards.RemoveRange(delete);
                db.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            return HttpNotFound();
        }
    }
}