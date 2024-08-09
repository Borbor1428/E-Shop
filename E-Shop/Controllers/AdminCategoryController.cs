﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrate;
using EmptyLayer.Entities;

namespace E_Shop.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CatagoryRepository categoryRepository = new CatagoryRepository();
        public ActionResult Index()
        {
            return View(categoryRepository.List());
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        
        public ActionResult Create(Category p)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Insert(p);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();
        }

        public ActionResult Delete(int d)
        {
            var delete = categoryRepository.GetById(d);
            categoryRepository.Delete(delete);
            return RedirectToAction("Index");
        }
        public ActionResult Update(){

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Category p)
        {
            if (ModelState.IsValid)
            {
                var update = categoryRepository.GetById(p.Id);
            update.Name = p.Name;
            update.Description = p.Description;
            categoryRepository.Update(update);
            return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();

        }
    }
}