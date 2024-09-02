using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrate;
using DataAccessLayer.Context;
using EmptyLayer.Entities;

namespace E_Shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public PartialViewResult PopularProduct()
        {
            var product = productRepository.GetPopularProduct();
            ViewBag.popular = product;
            return PartialView();
        }
        public ActionResult ProductDetails(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Session["userid"] != null)
                {
                    var details = productRepository.GetById(id);
                    return View(details);
                }
                else { return RedirectToAction("Login", "Account"); }
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Comment(Comment data)
        {
            if (User.Identity.IsAuthenticated)
            {
                db.Comments.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpGet]
        public ActionResult CommentGet(int id)
        {
            var getupdate = db.Comments.Where(x => x.Id == id).FirstOrDefault();

            return View(getupdate);
        }


        [HttpPost]
        public ActionResult CommentGet(Comment data)
        {
            if (User.Identity.IsAuthenticated)
            {

                var update = db.Comments.Where(x => x.Id == data.Id).FirstOrDefault();
                update.Contents = data.Contents;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Account");

        }
    }
}