using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class StockManage
    {
        static public List<Dictionary<string, string>> QueryAll(out decimal total,out string msg) {
            total = 0m;
            List<Dictionary<string, string>> list=StockDAL.QueryAllStockDetail(out msg);
            if (list == null) return null;
            foreach (Dictionary<string, string> dictionary in list) {
                total+= decimal.Parse(dictionary["money"]);
            }
            return list;
        }

        static public List<Indetail> QueryInDetail(int stockID, out string msg) {
            return IndetailDAL.QueryByStockID(stockID, out msg);
        }

        static public List<Dictionary<string, string>> Query(string num, out string msg){
             return StockDAL.QueryStockDetail(num, out msg);
        }
    }
}