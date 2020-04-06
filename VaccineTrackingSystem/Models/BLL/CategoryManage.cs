using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class CategoryManage
    {
        static public bool Add(Category category, out string msg)
        {
            if (CategoryDAL.Add(category, out msg))
                return true;
            return false;
        }

        static public bool Update(Category category, out string msg)
        {
            if (CategoryDAL.Update(category, out msg))
                return true;
            return false;
        }
        static public Category Query(string num, out string msg)
        {
            if (CategoryDAL.Query(num, out msg) == null)
                return null;
            return CategoryDAL.Query(num, out msg);
        }
        static public List<Category> QueryAll(out string msg)
        {
            if (CategoryDAL.QueryAll(out msg) == null)
                return null;
            return CategoryDAL.QueryAll(out msg);
        }

    }
}