using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Models.Database;
namespace Shop.Models.DataModel
{
    public class AdminModels
    {
        Database.ShopDbContext db;
        public AdminModels()
        {
            db = new Database.ShopDbContext();
        }
        public string LogIn(string UserName,string PassWord)
        {
            var account = db.Admins.SingleOrDefault(x => x.UserName == UserName);
            if (account == null)
                return "Khong tim thay tai khoan";
            else
            {
                if (account.PassWord != PassWord)
                    return "Sai mat khau";
                else
                {
                    return "";
                }
            }
        }
        public int GetIdByUserName(string UserName)
        {
            return db.Admins.SingleOrDefault(x => x.UserName == UserName).AdminID;
        }
        public string GetNameById(int Id)
        {
            return db.Admins.SingleOrDefault(x => x.AdminID == Id).UserName;
        }
    }
}