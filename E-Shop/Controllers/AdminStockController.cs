using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrate;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Concrate;
using DataAccessLayer.Context;
using EmptyLayer.Entities;
using PagedList;

namespace E_Shop.Controllers
{
    public class AdminStockController : Controller
    {
        private DataContext db = new DataContext();
        private StockRepository stockRepository = new StockRepository();

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;
            var stocks = db.Stocks.OrderBy(s => s.Id).ToPagedList(page, pageSize);
            return View(stocks);
        }

        public ActionResult Create()
        {
            // Ürün listesini dropdown için hazırlama
            ViewBag.Products = GetProductSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stock stock)
        {
            if (ModelState.IsValid)
            {
                stockRepository.AddStock(stock);
                return RedirectToAction("Index");
            }

            // Eğer validasyon hatası varsa, dropdown tekrar doldurulur.
            ViewBag.Products = GetProductSelectList();
            return View(stock);
        }

        private List<SelectListItem> GetProductSelectList()
        {
            return db.Products.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();
        }
        public ActionResult Delete(int id)
        {
            var stock = stockRepository.GetById(id);
            if (stock != null)
            {
                stockRepository.Delete(stock);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        public ActionResult Update(int id)
        {
            var stock = stockRepository.GetById(id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            // Ürün listesini dropdown için hazırlama
            ViewBag.Products = GetProductSelectList();

            return View(stock);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Stock stock)
        {
            if (ModelState.IsValid)
            {
                stockRepository.Update(stock);
                return RedirectToAction("Index");
            }

            // Eğer validasyon hatası varsa, dropdown tekrar doldurulur.
            ViewBag.Products = GetProductSelectList();
            return View(stock);
        }



    }
}
