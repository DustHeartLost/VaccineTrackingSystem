using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class DestoryManage
    {
        static public List<Dictionary<string, string>> Query(int storeID, ref int totalPage, ref int currentPage, out string msg)
        {
            List<Stock> stockList = StockDAL.QueryByStoreId(storeID, out msg);
            if (stockList == null || stockList.Count == 0)
            {
                totalPage = 0;
                currentPage = -1;
                msg = "暂无库存记录";
                return null;
            }
            List<Dictionary<string, string>> indetails = new List<Dictionary<string, string>>();
            for (int i = 0; i < stockList.Count; i++)
            {
                List<Dictionary<string, string>> temp = IndetailDAL.QueryByStockID(stockList[i].id, out msg);
                if (temp != null && temp.Count != 0)
                {
                    indetails.AddRange(temp);
                }
            }
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd");
       
            for (int i = 0; i < indetails.Count; i++)
            {
                if (Convert.ToDateTime(indetails[i]["batchNum"]) >= Convert.ToDateTime(nowTime))
                {
                    indetails.Remove(indetails[i]);
                    i--;
                }
            }
            if (indetails == null || indetails.Count == 0)
            {
                totalPage = 0;
                currentPage = -1;
                msg = "库房暂无过期药品";
                return null;
            }
            List<Dictionary<string, string>> list = SortDate(indetails);
            totalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --totalPage;
            if (currentPage < totalPage)
                ++currentPage;
            try
            {
                return list.GetRange(currentPage * 10, 10);
            }
            catch
            {
                return list.GetRange(currentPage * 10, list.Count - currentPage * 10);
            }
        }
    
        static private List<Dictionary<string, string>> SortDate(List<Dictionary<string, string>> indetailList)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime nowdate = Convert.ToDateTime(date);
            int m = 0;
            DateTime tempdate;
            if (indetailList.Count == 0)
                return null;
            for (int i = 0; i < indetailList.Count - 1; i++)
            {
                m = i;
                string time1 = indetailList[i]["batchNum"];
                tempdate = Convert.ToDateTime(time1);
                for (int j = i + 1; j < indetailList.Count; j++)
                {
                    string time2 = indetailList[j]["batchNum"] ;
                    DateTime indetaildt = Convert.ToDateTime(time2);
                    if (indetaildt > tempdate)
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

        static public bool Destory(List<Indetail> indetails, string userNum, out string msg)
        {
            List<string> list = new List<string>();
            if (indetails == null || indetails.Count == 0)
            {
                msg = "没有记录需要销毁";
                return false;
            }
            for (int i = 0; i < indetails.Count; i++)
            {
                int outNum = indetails[i].quantity;
                indetails[i].quantity = 0;
                int stockId = indetails[i].stockID;
                Stock stock = StockDAL.QueryById(stockId, out msg);
                if (stock == null)
                {
                    msg = "库存查询失败";
                    return false;
                }
                stock.quantity -= outNum;
                stock.money = stock.money - outNum * indetails[i].price;
                if (stock.money < 0)
                {
                    msg = "金额出错";
                    return false;
                }
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                Outflow outflow = new Outflow(stock.cagNum, stock.storeID, date, userNum, outNum, indetails[i].price, indetails[i].batchNum, indetails[i].batchNum2,indetails[i].suppliers, "过期作废");
                if (indetails[i].quantity == 0)
                {

                    list.Add(string.Format(" delete from Indetail where id ={0}", indetails[i].id));
                    list.Add(string.Format("update Stock set cagNum = '{0}', storeID = {1}, quantity = {2}, money = {3} where id = {4} ", stock.cagNum, stock.storeID, stock.quantity, stock.money, stock.id));
                    list.Add(string.Format("insert into Outflow (cagNum,storeID,date,userNum,quantity,price,batchNum,batchNum2,suppliers,state) values('{0}',{1},'{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}')", outflow.cagNum, outflow.storeID, outflow.date, outflow.userNum, outflow.quantity, outflow.price, outflow.batchNum, outflow.batchNum2, outflow.suppliers, outflow.state)); 
                    
/*
                    if (!IndetailDAL.Delete(indetails[i].id, out msg))
                    {
                        msg = "单品明细删除失败";
                        return false;
                    }
                    if (!(StockDAL.Update(stock, out msg) && OutflowDAL.Add(outflow, out msg)))
                    {
                        msg = "销毁失败";
                        return false;
                    }*/
                }
                else
                {
                    list.Add(string.Format("update Indetail set stockID = {0},batchNum = '{1}',date = '{2}',quantity = {3},price = {4},batchNum2 = '{5}',suppliers = '{6}',note = '{7}'  where id = {8}", indetails[i].stockID, indetails[i].batchNum, indetails[i].date, indetails[i].quantity, indetails[i].price, indetails[i].batchNum2, indetails[i].suppliers, indetails[i].note, indetails[i].id));
                    list.Add(string.Format("update Stock set cagNum = '{0}', storeID = {1}, quantity = {2}, money = {3} where id = {4} ", stock.cagNum, stock.storeID, stock.quantity, stock.money, stock.id));
                    list.Add(string.Format("insert into Outflow (cagNum,storeID,date,userNum,quantity,price,batchNum,batchNum2,suppliers,state) values('{0}',{1},'{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}')", outflow.cagNum, outflow.storeID, outflow.date, outflow.userNum, outflow.quantity, outflow.price, outflow.batchNum, outflow.batchNum2, outflow.suppliers, outflow.state));
      
                    /*  bool bol = SQL.ExecuteTransaction(list);
                if (bol)
                {
                    msg = "销毁成功";
                }
                else
                {
                    msg = "销毁失败";
                    return false;
                }*/
                }
                /*      if (!(IndetailDAL.Update(indetails[i], out msg) && StockDAL.Update(stock, out msg) && OutflowDAL.Add(outflow, out msg)))
                   {
                       msg = "销毁失败";
                       return false;
                   }*/
            }
            for(int i=0;i<list.Count;i++)
            {
                System.Diagnostics.Debug.Write("###############################MAnage");
                System.Diagnostics.Debug.Write(list[i]+"\n");
            }
            bool bol = SQL.ExecuteTransaction(list);
            if (bol)
            {
                msg = "销毁成功";
            }
            else
            {
                msg = "销毁失败";
                return false;
            }
            msg = null;
            return true;
        }

    }
}