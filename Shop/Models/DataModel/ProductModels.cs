using System.Collections.Generic;
using System.Linq;
using Shop.Models.Database;
using System;
using PagedList;
namespace Shop.Models.DataModel
{
    public class ProductModels
    {
        ShopDbContext db;
        public ProductModels()
        {
            db = new ShopDbContext();
        }
        public List<string> CategoryName()
        {
            var list = from cate in db.ProductCategories select cate.Name;
            return list as List<string>;
        }
        public PagedList<Product> GetPagedList(int page,int pageSize)
        {
            var result = db.Products.OrderByDescending(x=>x.ID).ToPagedList(page, pageSize);
            return result as PagedList<Product>;
        }
        public bool Add(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool UpDate(int Id,Product product)
        {
            try
            {
                var Object = db.Products.Find(Id);
                Object.Name = product.Name;
                Object.code = product.code;
                Object.Image = product.Image;
                Object.Description = product.Description;
                Object.Price = product.Price;
                Object.PromotionalPrice = product.PromotionalPrice;
                Object.Quantity = product.Quantity;
                Object.OrderDisplay = product.OrderDisplay;
                Object.State = product.State;
                Object.CategoryID = product.CategoryID;
                Object.EditBy = product.EditBy;
                Object.EditDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                db.Products.Remove(db.Products.Find(Id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PagedList<Product> GetPagedListWithCategoryID(int CategoryID, int page,int pageSize)
        {
            var result = db.Products.Where(x=>x.CategoryID==CategoryID).OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
            return result as PagedList<Product>;
        }
    }
}
