using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using VaccineTrackingSystem.Models.DAL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.Models.BLL
{
    public class StockManage
    {

        static public string QueryInDetail(int stockID, ref int totalPage, ref int currentPage, out string msg)
        {
            List<Dictionary<string, string>> list = IndetailDAL.QueryByStockID(stockID, out msg);
            if (list == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            List<Alert> alerts = AlertDAL.QueryAll(out msg);
            if (alerts != null && alerts.Count != 0)
            {
                alerts = alerts.OrderBy(o => o.days).ToList();//升序
                for (int i = 0; i < list.Count; i++)
                {
                    int nowColor = AlertManage.GetInterval(list[i]["batchNum"], alerts);
                    if (nowColor != -1)
                    {
                        list[i].Add("color", alerts[nowColor].color.ToString());
                    }
                    else
                        list[i].Add("color", "");
                }
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

        static public string Query(int storeID, string num, out string msg, ref decimal money, ref int totalPage, ref int currentPage)
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

        static public string QueryAll(int storeID, string num, out string msg, ref decimal money, ref int totalPage, ref int currentPage, bool flag)
        {
            List<Dictionary<string, string>> list = StockDAL.QueryStockDetail(storeID, num, out msg);
            if (list == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            if (flag) return JsonConvert.SerializeObject(list);
            totalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            foreach (Dictionary<string, string> dictionary in list)
            {
                money += decimal.Parse(dictionary["money"]);
            }
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

        static public string CombinationQuery(int storeID, string keyWords, out string msg, ref int totalPage, ref int currentPage, out decimal money)
        {
            money = 0m;
            JObject keys = (JObject)JsonConvert.DeserializeObject(keyWords);
            List<Dictionary<string, string>> list = StockDAL.CombinationQuery(keys, storeID, out msg);
            if (list == null || list.Count == 0)
            {
                msg = "搜索结果为空";
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            foreach (Dictionary<string, string> dictionary in list)
            {
                money += decimal.Parse(dictionary["money"]);
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

        static public string ExportConbinationInflow(int storeID, string keyWords, out string msg, out decimal money)
        {
            money = 0m;
            JObject keys = (JObject)JsonConvert.DeserializeObject(keyWords);
            List<Dictionary<string, string>> list = StockDAL.CombinationQuery(keys, storeID, out msg);
            if (list == null || list.Count == 0)
            {
                msg = "没有需要导出的记录";
                return null;
            }
            msg = null;
            foreach (Dictionary<string, string> dictionary in list)
            {
                money += decimal.Parse(dictionary["money"]);
            }
            return JsonConvert.SerializeObject(list);
        }

    }
}