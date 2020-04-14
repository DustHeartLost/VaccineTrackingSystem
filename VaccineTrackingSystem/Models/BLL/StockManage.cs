using Newtonsoft.Json;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class StockManage
    {
       
        static public string QueryInDetail(int stockID, out string msg)
        {
            List < Indetail >list= IndetailDAL.QueryByStockID(stockID, out msg);
            return list == null ? null : JsonConvert.SerializeObject(list);
        }

        static public string Query(int storeID, string num, out string msg,ref decimal money, ref int totalPage, ref int currentPage)
        {
            List<Dictionary<string, string>> list = StockDAL.QueryStockDetail(storeID, num, out msg);
            if (list == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            totalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            foreach (Dictionary<string, string> dictionary in list)
            {
                money += decimal.Parse(dictionary["money"]);
            }
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