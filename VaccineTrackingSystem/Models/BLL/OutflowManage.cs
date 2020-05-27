using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VaccineTrackingSystem.Models.DAL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.Models.BLL
{
    public class OutflowManage
    {
        //默认库房列表
        static public string QueryStockByStoreID(int storeID, out string msg, ref int totalPage, ref int currentPage)
        {
            List<Dictionary<string, string>> list = StockDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null)
            {
                msg = "库存列表暂无记录";
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

        //根据药品编码查找库存记录
        static public string QueryByCagNum(string cagNum, int storeID, out string msg)
        {
            List<Dictionary<string, string>> list = StockDAL.QueryCagNum(cagNum, storeID, out msg);
            return list != null ? JsonConvert.SerializeObject(list) : null;
        }

        //根据药品名称模糊查找
        static public string QueryByCagName(string cagName, int storeID, out string msg)
        {
            List<Dictionary<string, string>> list = StockDAL.QueryCagName(cagName, storeID, out msg);
            return list != null ? JsonConvert.SerializeObject(list) : null;
        }

        //单品明细数据进行批号排序，返回list  4/7
        static public string QueryIndetail(int stockID, out string msg, ref int totalPage, ref int currentPage)
        {
            List<Dictionary<string, string>> list = IndetailDAL.QueryByStockID(stockID, out msg);
            List<Alert> alerts = AlertDAL.QueryAll(out msg);
            if (list == null)
            {
                msg = "不能出库过期产品";
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            //排序+过滤过期药品
            List<Dictionary<string, string>> sortList = SortDate(list);
            if (sortList == null)
            {
                msg = "暂无未过期的单品明细";
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            if (alerts != null && alerts.Count != 0)
            {
                alerts = alerts.OrderBy(o => o.days).ToList();//升序
                for (int i = 0; i < sortList.Count; i++)
                {
                    int nowColor = AlertManage.GetInterval(sortList[i]["batchNum"], alerts);
                    if (nowColor != -1)
                    {
                        sortList[i].Add("color", alerts[nowColor].color.ToString());
                    }
                    else
                        sortList[i].Add("color", "");
                }
            }

            totalPage = (int)System.Math.Floor((decimal)(sortList.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --totalPage;
            if (currentPage < totalPage)
                ++currentPage;
            try
            {
                return JsonConvert.SerializeObject(sortList.GetRange(currentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(sortList.GetRange(currentPage * 10, sortList.Count - currentPage * 10));
            }
        }

        static private List<Dictionary<string, string>> SortDate(List<Dictionary<string, string>> indetailList)
        {

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime nowdate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.CurrentCulture);
            int m = 0;
            DateTime tempdate;
            for (int i = 0; i < indetailList.Count; i++)
            {
                if (DateTime.ParseExact(indetailList[i]["batchNum"], "yyyy-MM-dd", CultureInfo.CurrentCulture) <= nowdate)
                {
                    indetailList.Remove(indetailList[i]);
                    i--;
                }
            }
            if (indetailList.Count == 0)
                return null;
            for (int i = 0; i < indetailList.Count - 1; i++)
            {
                m = i;
                tempdate = DateTime.ParseExact(indetailList[i]["batchNum"], "yyyy-MM-dd", CultureInfo.CurrentCulture);
                for (int j = i + 1; j < indetailList.Count; j++)
                {
                    DateTime indetaildt = DateTime.ParseExact(indetailList[j]["batchNum"], "yyyy-MM-dd", CultureInfo.CurrentCulture);
                    if (indetaildt < tempdate)
                    {
                        tempdate = indetaildt;
                        m = j;
                    }
                }
                if (m != i)
                    indetailList = Swap(indetailList, m, i);
            }
            return indetailList;
        }

        static private List<Dictionary<string, string>> Swap(List<Dictionary<string, string>> indetailList, int m, int i)
        {
            Dictionary<string, string> t;
            t = indetailList[m];
            indetailList[m] = indetailList[i];
            indetailList[i] = t;
            return indetailList;
        }
        //出库
        static public bool OutWarehouse(int indetailId, int outNum, string userNum, out string msg)
        {
            List<string> list = new List<string>();
            Indetail indetail = IndetailDAL.QueryById(indetailId, out msg);
            if (indetail == null)
            {
                msg = "单品记录查询失败";
                return false;
            }
            if (indetail.quantity < outNum)
            {
                msg = "数量不足";
                return false;
            }
            indetail.quantity -= outNum;
            int stockId = indetail.stockID;
            Stock stock = StockDAL.QueryById(stockId, out msg);
            if (stock == null)
            {
                msg = "库存查询失败";
                return false;
            }
            stock.quantity -= outNum;
            stock.money = stock.money - outNum * indetail.price;
            if (stock.money < 0)
            {
                msg = "金额出错";
                return false;
            }
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            Outflow outflow = new Outflow(stock.cagNum, stock.storeID, date, userNum, outNum, indetail.price, indetail.batchNum, indetail.batchNum2, indetail.suppliers, "正常出库");
            if (indetail.quantity == 0)
            {
                list.Add(string.Format(" delete from Indetail where id ={0}", indetailId));
                list.Add(string.Format("update Stock set cagNum = '{0}', storeID = {1}, quantity = {2}, money = {3} where id = {4} ", stock.cagNum, stock.storeID, stock.quantity, stock.money, stock.id));
                list.Add(string.Format("insert into Outflow (cagNum,storeID,date,userNum,quantity,price,batchNum,batchNum2,suppliers,state) values('{0}',{1},'{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}')", outflow.cagNum, outflow.storeID, outflow.date, outflow.userNum, outflow.quantity, outflow.price, outflow.batchNum, outflow.batchNum2, outflow.suppliers, outflow.state));
            }
            else
            {
                list.Add(string.Format("update Indetail set stockID = {0},batchNum = '{1}',date = '{2}',quantity = {3},price = {4},batchNum2 = '{5}',suppliers = '{6}',note = '{7}'  where id = {8}", indetail.stockID, indetail.batchNum, indetail.date, indetail.quantity, indetail.price, indetail.batchNum2, indetail.suppliers, indetail.note, indetail.id));
                list.Add(string.Format("update Stock set cagNum = '{0}', storeID = {1}, quantity = {2}, money = {3} where id = {4} ", stock.cagNum, stock.storeID, stock.quantity, stock.money, stock.id));
                list.Add(string.Format("insert into Outflow (cagNum,storeID,date,userNum,quantity,price,batchNum,batchNum2,suppliers,state) values('{0}',{1},'{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}')", outflow.cagNum, outflow.storeID, outflow.date, outflow.userNum, outflow.quantity, outflow.price, outflow.batchNum, outflow.batchNum2, outflow.suppliers, outflow.state));
            }
            bool bol = SQL.ExecuteTransaction(list, out msg);
            if (bol)
            {
                msg = "出库成功";
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}