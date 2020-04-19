using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class DestoryManage
    {
        static public List<Indetail> Query(int storeID, ref int totalPage, ref int currentPage, out string msg)
        {
            List<Stock> stockList = StockDAL.QueryByStoreId(storeID, out msg);
            if (stockList == null || stockList.Count == 0)
            {
                totalPage = 0;
                currentPage = -1;
                msg = "暂无库存记录";
                return null;
            }
            List<Indetail> indetails = new List<Indetail>();
            for (int i = 0; i < stockList.Count; i++)
            {
                List<Indetail> temp = IndetailDAL.QueryByStockID(stockList[i].id, out msg);
                if (temp != null && temp.Count != 0)
                {
                    indetails.AddRange(temp);
                }
            }
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd");

            for (int i = 0; i < indetails.Count; i++)
            {
                if (Convert.ToDateTime(indetails[i].batchNum) > Convert.ToDateTime(nowTime))
                {
                    indetails.Remove(indetails[i]);
                    i--;
                }
            }
            if (indetails == null || indetails.Count == 0)
            {
                totalPage = 0;
                currentPage = -1;
                msg = "库房暂无单品明细记录";
                return null;
            }
            List<Indetail> list = SortDate(indetails);
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
    
        static private List<Indetail> SortDate(List<Indetail> indetailList)
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
                tempdate = Convert.ToDateTime(indetailList[i].batchNum);
                for (int j = i + 1; j < indetailList.Count; j++)
                {
                    DateTime indetaildt = Convert.ToDateTime(indetailList[j].batchNum);
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
        static private List<Indetail> Swap(List<Indetail> indetailList, int m, int i)
        {
            Indetail t;
            t = indetailList[m];
            indetailList[m] = indetailList[i];
            indetailList[i] = t;
            return indetailList;
        }

        static public bool Destory(List<Indetail> indetails, string userNum, out string msg)
        {
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
                Outflow outflow = new Outflow(stock.cagNum, stock.storeID, date, userNum, outNum, indetails[i].price, indetails[i].batchNum, "过期作废");
                if (indetails[i].quantity == 0)
                {
                    if (!IndetailDAL.Delete(indetails[i].id, out msg))
                    {
                        msg = "单品明细删除失败";
                        return false;
                    }
                    if (!(StockDAL.Update(stock, out msg) && OutflowDAL.Add(outflow, out msg)))
                    {
                        msg = "销毁失败";
                        return false;
                    }
                }
                else
                   if (!(IndetailDAL.Update(indetails[i], out msg) && StockDAL.Update(stock, out msg) && OutflowDAL.Add(outflow, out msg)))
                {
                    msg = "销毁失败";
                    return false;
                }
            }
            msg = null;
            return true;
        }

    }
}