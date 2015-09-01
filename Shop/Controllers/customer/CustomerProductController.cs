using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models.DataModel;
namespace Shop.Controllers.customer
{
    public class CustomerProductController : Controller
    {
        // GET: CustomerProduct
        public ActionResult Index(int id = 1, int page = 1, int pageSize = 10)
        {
            ViewBag.ListCatgory = new ProductCategoryModels().GetListCategory();
            ViewBag.Seleted = new Shop.Models.Database.ShopDbContext().ProductCategories.Find(id);
            return View(new ProductModels().GetPagedListWithCategoryID(id,page, pageSize));
        }
    }
}