using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class CategoryManage
    {
        static public bool Add(Category category, string msg)
        {
            if (CategoryDAL.Add(category, msg))
                return true;
            return false;
        }

        static public bool Update(Category category,string msg)
        {
            if (CategoryDAL.Update(category, msg))
                return true;
            return false;
        }
        static public Category Query(string num, string msg)
        {
            if (CategoryDAL.Query(num, msg) == null)
                return null;
            return CategoryDAL.Query(num, msg);
        }
        static public List<Category> QueryAll(string msg)
        {
            if (CategoryDAL.QueryAll(msg) == null)
                return null;
            return CategoryDAL.QueryAll(msg);
        }

    }
}