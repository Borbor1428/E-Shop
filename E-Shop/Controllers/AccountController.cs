using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using DataAccessLayer.Context;
using EmptyLayer.Entities;
using EShop.Controllers;

namespace E_Shop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DataContext db = new DataContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(User data)
        {
            var info = db.Users.FirstOrDefault(x => x.Mail == data.Mail && x.Password == data.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Mail, false);
                Session["Mail"] = info.Mail.ToString();
                Session["Ad"] = info.Name.ToString();
                Session["Soyad"] = info.Surname.ToString();
                Session["UserId"] = info.UserId.ToString();
                return RedirectToActionPermanent("Index", "Home");
            }
            ViewBag.error = "Mail veya şifre yanlış girilmiştir";
            return View(data);
        }
        public ActionResult Register (User data)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(data);
                data.Role = "User";
                db.SaveChanges();
                return RedirectToActionPermanent("Login");
            }
            ModelState.AddModelError("", "Hatalı");
            return View("Login", data);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Remove("Ad");

            return RedirectToAction("Index", "Home");
        }
        //public ActionResult SifreReset()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult SifreReset(string Email)
        //{
        //    var mail = db.Users.Where(x => x.Mail == Email).SingleOrDefault();

        //    if (mail != null)
        //    {
        //        Random rnd = new Random();
        //        int yenisifre = rnd.Next();
        //        User sifre = new User();
        //        mail.Password = (Convert.ToString(yenisifre));
        //        db.SaveChanges();
        //        WebMail.SmtpServer = "smtp.gmail.com";
        //        WebMail.EnableSsl = true;
        //        WebMail.UserName = "kurumsalweb7@gmail.com";
        //        WebMail.Password = "kurumsal12345";
        //        WebMail.SmtpPort = 587;
        //        WebMail.Send(Email, "Giriş Şifreniz", "Şifreniz:" + yenisifre);
        //        ViewBag.uyari = "Şifre gönderildi";
        //    }
        //    else
        //    {
        //        ViewBag.uyari = "Şifre gönderilmedi";
        ////    }





        //    return View();
        //}
    }
}