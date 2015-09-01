using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models.Database;
using Shop.Models.DataModel;
namespace Shop.Controllers.Admin
{
    public class AdminProductCategoryController : Controller
    {
        // GET: AdminProductCategory
        public ActionResult Index(int page=1,int pageSize=10)
        {
            return View(new ProductCategoryModels().GetProductCategory(page,pageSize));
        }

        // GET: AdminProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View(new Shop.Models.Database.ShopDbContext().ProductCategories.Find(id));
        }

        // GET: AdminProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminProductCategory/Create
        [HttpPost]
        public ActionResult Create(ProductCategory Object,string ParentName)
        {
            try
            {
                if (ParentName == "Khong Co")
                    Object.ParentID = 0;
                else
                    Object.ParentID = new ProductCategoryModels().GetIdByName(ParentName);
                Object.CreateBy = new Shop.Models.DataModel.AdminModels().GetIdByUserName(Session[Shop.Models.SupportModel.SessionKey.LogIn] as string);
                Object.CreateDate = DateTime.Now;
                Object.EditBy= new Shop.Models.DataModel.AdminModels().GetIdByUserName(Session[Shop.Models.SupportModel.SessionKey.LogIn] as string);
                Object.EditDate = DateTime.Now;
                bool check = new ProductCategoryModels().Add(Object);
                if(check)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Shop.Models.Database.ShopDbContext().ProductCategories.Find(id));
        }

        // POST: AdminProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductCategory Object, string ParentName)
        {
            try
            {
                if (ParentName == "Khong Co")
                    Object.ParentID = 0;
                Object.EditBy = new Shop.Models.DataModel.AdminModels().GetIdByUserName(Session[Shop.Models.SupportModel.SessionKey.LogIn] as string);
                Object.EditDate = DateTime.Now;
                bool check = new ProductCategoryModels().UpDate(id,Object);
                if (check)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Shop.Models.Database.ShopDbContext().ProductCategories.Find(id));
        }

        // POST: AdminProductCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (new ProductCategoryModels().Delete(id))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
