using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrate;
using DataAccessLayer.Context;
using EmptyLayer.Entities;
using PagedList.Mvc;
using PagedList;
using Newtonsoft.Json.Linq;

namespace E_Shop.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public ActionResult Index(int page=1)
        {

            return View(productRepository.List().ToPagedList(page, 3));
        }
        public ActionResult Create()
        {
            List<SelectListItem> value1 = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = value1;
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Product data, HttpPostedFileBase File, int StockQuantity)
        {
            if (!ModelState.IsValid)
            {

                string path = Path.Combine("~/Content/Image/" + File.FileName);
                File.SaveAs(Server.MapPath(path));
                data.Image = File.FileName.ToString();
                productRepository.Insert(data);
                return RedirectToAction("Index");
            }
            Stock stock = new Stock
            {
                ProductId = data.Id, // Yeni eklenen ürünün Id'si
                Quantity = StockQuantity // Formdan alınan stok miktarı
            };
            db.Stocks.Add(stock);
            db.SaveChanges();

            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var product = productRepository.GetById(id);
            productRepository.Delete(product);

            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> value1 = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = value1;
            var product = productRepository.GetById(id);
            return View(product);


        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Product data, HttpPostedFileBase File, int StockQuantity)
        {
            var product = productRepository.GetById(data.Id);
            if (!ModelState.IsValid)
            {
                if (File == null)
                {
                    product.Description = data.Description;
                    product.Name = data.Name;
                    product.Popular = data.Popular;
                    product.Price = data.Price;
                    product.IsApproved = data.IsApproved;
                    product.CategoryId = data.CategoryId;
                    

                    productRepository.Update(product);
                    return RedirectToAction("Index");
                }
                else
                {
                    product.Image = File.FileName.ToString();
                    product.Description = data.Description;
                    product.Name = data.Name;
                    product.Popular = data.Popular;
                    product.Price = data.Price;
                    product.IsApproved = data.IsApproved;
                    product.CategoryId = data.CategoryId;
                    
                    productRepository.Update(product);
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }
    }
}