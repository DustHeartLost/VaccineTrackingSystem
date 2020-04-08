using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class CategoryManage
    {
        static public bool Add(Category category, out string msg)
        {
            return CategoryDAL.Add(category, out msg);
        }

        static public bool Update(Category category, out string msg)
        {
            return CategoryDAL.Update(category, out msg);
        }
        static public Category Query(string num, out string msg)
        {
            return CategoryDAL.Query(num, out msg);
        }
        static public List<Category> QueryAll(out string msg)
        {
            return CategoryDAL.QueryAll(out msg);
        }

    }
}