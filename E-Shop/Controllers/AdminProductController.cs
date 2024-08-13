using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrate;
using DataAccessLayer.Context;
using EmptyLayer.Entities;

namespace E_Shop.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(productRepository.List());
        }
        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Product data, HttpPostedFileBase File)
        {
            if (!ModelState.IsValid)
            {

                string path = Path.Combine("~/Content/Image/" + File.FileName);
                File.SaveAs(Server.MapPath(path));
                data.Image = File.FileName.ToString();
                productRepository.Insert(data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
    }
}