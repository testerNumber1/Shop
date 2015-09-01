using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models.Database;
using PagedList;
namespace Shop.Models.DataModel
{
    public class ProductCategoryModels
    {
        ShopDbContext db;
        public ProductCategoryModels()
        {
            db = new ShopDbContext();
        }
        public List<string> GetListId(int Id)
        {
            var list = db.ProductCategories.ToList();
            List<string> listName= new List<string>();
            listName.Add("Khong Co");
            foreach (var item in list)
            {
                if(item.ID!=Id)
                    listName.Add(item.Name);
            }
            return listName;
        }
        public string GetNameById(int? Id)
        {
            return db.ProductCategories.SingleOrDefault(x => x.ID == Id).Name;
        }
        public int GetIdByParentID(string ParentID)
        {
            return db.ProductCategories.SingleOrDefault(x => x.Name == ParentID).ID;
        }
        public PagedList<ProductCategory> GetProductCategory(int page,int pageSize)
        {
            var a=db.ProductCategories.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
            return a as PagedList<ProductCategory>;
        }
        public int GetIdByName(string name)
        {
            return db.ProductCategories.SingleOrDefault(x => x.Name == name).ID;
        }
        public bool Add(ProductCategory category)
        {
            try
            {
                db.ProductCategories.Add(category);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpDate(int id,ProductCategory category)
        {

            try
            {
                var Object = db.ProductCategories.Find(id);
                Object.Name = category.Name;
                Object.OrderDisplay = category.OrderDisplay;
                Object.ParentID = category.OrderDisplay;
                Object.State = category.State;
                Object.Title = category.Title;
                Object.EditBy = category.EditBy;
                Object.EditDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                db.ProductCategories.Remove(db.ProductCategories.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ProductCategory> GetListCategory()
        {
            return db.ProductCategories.ToList();
        }
    }
}
