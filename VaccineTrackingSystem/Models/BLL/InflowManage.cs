using DAL;
using Newtonsoft.Json;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class InflowManage
    {
        static public string QueryTodayRecoder(int storeID, string nowTime, out string msg, ref int totalPage, ref int currentPage)
        {
            List<Dictionary<string, string>> list = InflowDAL.QueryTodayRecoder(storeID, nowTime, out msg);
            if (list == null)
            {
                msg = "今日无入库记录";
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

        static public bool InWarehouse(Inflow inflow, out string msg)
        {
            List<string> list = new List<string>();
            list.Add(string.Format(" insert into Inflow (cagNum,storeID,date,userNum,quantity,price,batchNum,batchNum2,suppliers) values ('{0}',{1},'{2}','{3}',{4},{5},'{6}','{7}','{8}')", inflow.cagNum, inflow.storeID, inflow.date, inflow.userNum, inflow.quantity, inflow.price, inflow.batchNum, inflow.batchNum2, inflow.suppliers));
            if (StockDAL.QueryByCagNum(inflow.cagNum, inflow.storeID, out msg) == null)
            {
                Stock stock = new Stock(inflow.cagNum, inflow.storeID, 0, 0);
                list.Add(string.Format("insert into Stock (cagNum,storeID,quantity,money) values ('{0}',{1},{2},{3})", stock.cagNum, stock.storeID, stock.quantity, stock.money));
            }

            list.Add(string.Format("update Stock set cagNum = '{0}', storeID = {1}, quantity = quantity+{2}, money = money+{2}*{3} where id in (select id as stockId from Stock where cagNum = '{0}' and storeID = {1}) ", inflow.cagNum, inflow.storeID, inflow.quantity, inflow.price));

            list.Add(string.Format("insert into Indetail (stockID,batchNum,date,quantity,price,batchNum2,suppliers,note) values ((select id as stockId from Stock where cagNum = '{0}' and storeID = {1}),'{2}','{3}',{4},{5},'{6}','{7}','{8}') ", inflow.cagNum, inflow.storeID, inflow.batchNum, inflow.date, inflow.quantity, inflow.price, inflow.batchNum2, inflow.suppliers, inflow.notes));
            bool bol = SQL.ExecuteTransaction(list, out msg);
            if (bol)
            {
                msg = "入库成功";
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}