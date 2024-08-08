using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrate;

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
    }
}