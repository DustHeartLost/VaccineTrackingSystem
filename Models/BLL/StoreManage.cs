using Newtonsoft.Json;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class StoreManage
    {
        static public bool Add(Storeroom storeroom, out string msg)
        {
            return StoreroomDAL.Add(storeroom, out msg);
        }
        static public bool Update(Storeroom storeroom, out string msg)
        {
            return StoreroomDAL.Update(storeroom, out msg);
        }
        static public string Query(string name, out string msg)
        {
            List<Dictionary<string, string>> storerooms = StoreroomDAL.Query(name, out msg);
            if (storerooms == null)
                return null;
            return JsonConvert.SerializeObject(storerooms);
        }
        static public string QueryAll(out string msg, ref int totalPage, ref int currentPage)
        {
            List<Dictionary<string, string>> list = StoreroomDAL.QueryAll(out msg);
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