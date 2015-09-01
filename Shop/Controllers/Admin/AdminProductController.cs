using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models.DataModel;
using Shop.Models.Database;
using System.IO;

namespace Shop.Controllers.Admin
{
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            return View(new ProductModels().GetPagedList(page, pageSize));
        }

        // GET: AdminProduct/Details/5
        public ActionResult Details(int id)
        {
            return View(new Shop.Models.Database.ShopDbContext().Products.Find(id));
        }

        // GET: AdminProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminProduct/Create
        [HttpPost]
        public ActionResult Create(Product Object,string CategoryName)
        {
            try
            {
                HttpPostedFileBase anh = HttpContext.Request.Files["MyImage"];
                byte[] MyImage = new byte[anh.ContentLength];
                anh.InputStream.Read(MyImage, 0, anh.ContentLength);
                Object.Image = MyImage;
                if (CategoryName == "Khong Co")
                    Object.CategoryID = 0;
                else
                    Object.CategoryID = new Shop.Models.DataModel.ProductCategoryModels().GetIdByName(CategoryName);
                Object.CreateBy = new Shop.Models.DataModel.AdminModels().GetIdByUserName(Session[Shop.Models.SupportModel.SessionKey.LogIn] as string);
                Object.CreateDate = DateTime.Now;
                Object.EditBy = new Shop.Models.DataModel.AdminModels().GetIdByUserName(Session[Shop.Models.SupportModel.SessionKey.LogIn] as string);
                Object.EditDate = DateTime.Now;
                bool check = new ProductModels().Add(Object);
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

        // GET: AdminProduct/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Shop.Models.Database.ShopDbContext().Products.Find(id));
        }

        // POST: AdminProduct/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product Object, string CategoryName)
        {
            try
            {
                HttpPostedFileBase anh = HttpContext.Request.Files["MyImage"];
                byte[] MyImage = new byte[anh.ContentLength];
                anh.InputStream.Read(MyImage, 0, anh.ContentLength);
                Object.Image = MyImage;
                if (CategoryName == "Khong Co")
                    Object.CategoryID = 0;
                else
                    Object.CategoryID = new Shop.Models.DataModel.ProductCategoryModels().GetIdByName(CategoryName);
                Object.EditBy = new Shop.Models.DataModel.AdminModels().GetIdByUserName(Session[Shop.Models.SupportModel.SessionKey.LogIn] as string);
                Object.EditDate = DateTime.Now;
                bool check = new ProductModels().UpDate(id,Object);
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

        // GET: AdminProduct/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Shop.Models.Database.ShopDbContext().Products.Find(id));
        }

        // POST: AdminProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var check = new ProductModels().Delete(id);
                if (check)
                    return RedirectToAction("Index");
                else return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetImage(int id)
        {
            ShopDbContext db = new ShopDbContext();
            Product hinhanh = db.Products.Find(id);

            HinhAnhResult result = new HinhAnhResult(hinhanh.Image);
            return result;
        }
    }

    public class HinhAnhResult : ActionResult
    {
        public byte[] NoiDungHinhAnh { get; set; }

        public HinhAnhResult(byte[] noidung)
        {
            NoiDungHinhAnh = noidung;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (NoiDungHinhAnh != null)
            {
                var stream = new MemoryStream(NoiDungHinhAnh);
                stream.WriteTo(response.OutputStream);
                stream.Dispose();
            }
        }
    }
}
