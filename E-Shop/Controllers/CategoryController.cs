using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrate;
using DataAccessLayer.Context;

namespace E_Shop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CatagoryRepository categoryRepository = new CatagoryRepository();
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public PartialViewResult CategoryList()
        {
            var category = categoryRepository.List();
            ViewBag.list = category;
            return PartialView(category);
        }
    }
}