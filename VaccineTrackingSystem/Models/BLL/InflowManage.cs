using DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class InflowManage
    {
        static public string QueryTodayRecoder(int storeID, string nowTime, out string msg, ref int totalPage, ref int currentPage)
        {
             List<Dictionary<string,string>> list=InflowDAL.QueryTodayRecoder(storeID, nowTime, out msg);
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
            list.Add(string.Format(" insert into Inflow (cagNum,storeID,date,userNum,quantity,price,batchNum,batchNum2,suppliers) values ('{0}',{1},'{2}','{3}',{4},{5},'{6}','{7}','{8}')", inflow.cagNum,inflow.storeID, inflow.date, inflow.userNum, inflow.quantity, inflow.price, inflow.batchNum, inflow.batchNum2, inflow.suppliers));
            if (StockDAL.QueryByCagNum(inflow.cagNum, inflow.storeID, out msg) == null)
            {
                Stock stock = new Stock(inflow.cagNum, inflow.storeID, 0, 0);
                list.Add(string.Format("insert into Stock (cagNum,storeID,quantity,money) values ('{0}',{1},{2},{3})", stock.cagNum, stock.storeID, stock.quantity, stock.money));
            }
            Stock s = StockDAL.QueryByCagNum(inflow.cagNum, inflow.storeID, out msg);
            if (s == null)
            {
                msg = "未查询到库存记录";
                return false;
            }
            s.quantity += inflow.quantity;
            s.money = s.money + inflow.quantity * inflow.price;
            list.Add(string.Format("update Stock set cagNum = '{0}', storeID = {1}, quantity = {2}, money = {3} where id = {4} ", s.cagNum, s.storeID, s.quantity, s.money, s.id));

            //if (IndetailDAL.Query(s.id, inflow.batchNum, inflow.date, inflow.price,inflow.batchNum2,inflow.suppliers, out msg) == null)
            //{
           
            Indetail indetail = new Indetail(s.id, inflow.batchNum, inflow.date, inflow.quantity, inflow.price,inflow.batchNum2,inflow.suppliers,inflow.notes);
            list.Add(string.Format("insert into Indetail (stockID,batchNum,date,quantity,price,batchNum2,suppliers,note) values ({0},'{1}','{2}',{3},{4},'{5}','{6}','{7}')", indetail.stockID, indetail.batchNum, indetail.date, indetail.quantity, indetail.price, indetail.batchNum2, indetail.suppliers, indetail.note));
            //Indetail i = IndetailDAL.Query(s.id, inflow.batchNum, inflow.date, inflow.price, inflow.batchNum2, inflow.suppliers, out msg);
            //if (i == null)
            //{
            //    //msg = "单品明细表查询记录失败";
            //    return false;
            //}
            //i.quantity += inflow.quantity;
            //i.note += inflow.notes;
            //if (!IndetailDAL.Update(i, out msg))
            //{
            //    //msg = "单品明细表增添记录失败";
            //    return false;
            //}
            /*for (int i = 0; i < list.Count; i++)
            {
                System.Diagnostics.Debug.Write("###############################MAnage");
                System.Diagnostics.Debug.Write(list[i] + "\n");
            }*/
            bool bol = SQL.ExecuteTransaction(list);
            if (bol)
            {
                msg = "入库成功";
            }
            else
            {
                msg = "入库失败";
                return false;
            }
            return true;
        }
    }
}