using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class TableManage
    {
        static public string queryAllInflow(int storeID, ref int inflowTotalPage, ref int inflowCurrentPage, out string msg, out decimal money)
        {
            money = 0m;
            List<Dictionary<string, string>> list = InflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null)
            {
                inflowTotalPage = 0;
                inflowCurrentPage = -1;
                return null;
            }
            msg = null;
            foreach (Dictionary<string, string> d in list)
            {
                money += decimal.Parse(d["price"]) * decimal.Parse(d["quantity"]);
            }
            inflowTotalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --inflowTotalPage;
            if (inflowCurrentPage < inflowTotalPage)
                ++inflowCurrentPage;
            try
            {
                return JsonConvert.SerializeObject(list.GetRange(inflowCurrentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(list.GetRange(inflowCurrentPage * 10, list.Count - inflowCurrentPage * 10));
            }
        }

        static public string queryAllOutflow(int storeID, ref int outflowTotalPage, ref int outflowCurrentPage, out string msg, out decimal money)
        {
            money = 0m;
            List<Dictionary<string, string>> list = OutflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null)
            {
                outflowTotalPage = 0;
                outflowCurrentPage = -1;
                return null;
            }
            msg = null;
            foreach (Dictionary<string, string> d in list)
            {
                money += decimal.Parse(d["price"]) * decimal.Parse(d["quantity"]);
            }
            outflowTotalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --outflowTotalPage;
            if (outflowCurrentPage < outflowTotalPage)
                ++outflowCurrentPage;
            try
            {
                return JsonConvert.SerializeObject(list.GetRange(outflowCurrentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(list.GetRange(outflowCurrentPage * 10, list.Count - outflowCurrentPage * 10));
            }
        }

        static public string ExportInflow(int storeID, out string msg, out decimal money)
        {
            money = 0m;
            List<Dictionary<string, string>> list = InflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null)
            {
                msg = "没有需要导出的记录";
                return null;
            }
            msg = null;
            foreach (Dictionary<string, string> d in list)
            {
                money += decimal.Parse(d["price"]) * decimal.Parse(d["quantity"]);
            }
            return JsonConvert.SerializeObject(list);
        }

        static public string ExportOutflow(int storeID, out string msg, out decimal money)
        {
            money = 0m;
            List<Dictionary<string, string>> list = OutflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null)
            {
                msg = "没有需要导出的记录";
                return null;
            }
            msg = null;
            foreach (Dictionary<string, string> d in list)
            {
                money += decimal.Parse(d["price"]) * decimal.Parse(d["quantity"]);
            }
            return JsonConvert.SerializeObject(list);
        }

        static public string InflowCombinationQuery(int storeID, string keyWords, out string msg, ref int totalPage, ref int currentPage, out decimal money)
        {
            money = 0m;
            JObject keys = (JObject)JsonConvert.DeserializeObject(keyWords);
            List<Dictionary<string, string>> list = InflowDAL.CombinationQuery(keys, storeID, out msg);
            if (list == null)
            {
                msg = "搜索结果为空";
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            foreach (Dictionary<string, string> d in list)
            {
                money += decimal.Parse(d["price"]) * decimal.Parse(d["quantity"]);
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
            List<Dictionary<string, string>> list = InflowDAL.CombinationQuery(keys, storeID, out msg);
            if (list == null)
            {
                msg = "没有需要导出的记录";
                return null;
            }
            msg = null;
            foreach (Dictionary<string, string> d in list)
            {
                money += decimal.Parse(d["price"]) * decimal.Parse(d["quantity"]);
            }
            return JsonConvert.SerializeObject(list);
        }

        static public string OutflowCombinationQuery(int storeID, string keyWords, out string msg, ref int totalPage, ref int currentPage, out decimal money)
        {
            money = 0m;
            JObject keys = (JObject)JsonConvert.DeserializeObject(keyWords);
            List<Dictionary<string, string>> list = OutflowDAL.CombinationQuery(keys, storeID, out msg);
            if (list == null)
            {
                msg = "搜索结果为空";
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            foreach (Dictionary<string, string> d in list)
            {
                money += decimal.Parse(d["price"]) * decimal.Parse(d["quantity"]);
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

        static public string ExportConbinationOutflow(int storeID, string keyWords, out string msg, out decimal money)
        {
            money = 0m;
            JObject keys = (JObject)JsonConvert.DeserializeObject(keyWords);
            List<Dictionary<string, string>> list = OutflowDAL.CombinationQuery(keys, storeID, out msg);
            if (list == null)
            {
                msg = "没有需要导出的记录";
                return null;
            }
            msg = null;
            foreach (Dictionary<string, string> d in list)
            {
                money += decimal.Parse(d["price"]) * decimal.Parse(d["quantity"]);
            }
            return JsonConvert.SerializeObject(list);
        }

    }
}