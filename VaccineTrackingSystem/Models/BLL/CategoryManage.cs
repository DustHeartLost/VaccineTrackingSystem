using Newtonsoft.Json;
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
        static public string Query(string num, out string msg)
        {
            List<Category> list = new List<Category>();
            if (CategoryDAL.Query(num, out msg) != null)
                list.Add(CategoryDAL.Query(num, out msg));
            else
                return null;
            return JsonConvert.SerializeObject(list);
        }
        static public string QueryAll(out string msg, ref int totalPage, ref int currentPage)
        {
            List<Category> list = CategoryDAL.QueryAll(out msg);
            if (list == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            totalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --totalPage;
            if (currentPage < totalPage)
                ++currentPage;
            try
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, list.Count - currentPage * 10));
            }
        }

    }
}