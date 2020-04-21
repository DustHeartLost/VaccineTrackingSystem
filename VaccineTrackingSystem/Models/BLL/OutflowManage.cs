﻿using System;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;
using Newtonsoft.Json;

namespace VaccineTrackingSystem.Models.BLL
{
    public class OutflowManage
    {
        //新增根据药品编码查询库存表   4/7
        static public string QueryStrock(String cagNum, int storeID, out string msg)
        {
            Stock stock = StockDAL.QueryByCagNum(cagNum, storeID, out msg);
            List<Stock> stockList = new List<Stock>();
            if (stock == null)
            {
                msg = "该库房暂无该药品";
                return null;
            }
            stockList.Add(stock);
            return JsonConvert.SerializeObject(stockList);
        }


        //新增 单品明细数据进行批号排序，返回list  4/7
        static public string QueryIndetail(int stockID, out string msg, ref int totalPage, ref int currentPage)
        {
            List<Dictionary<string,string>> list= IndetailDAL.QueryByStockID(stockID, out msg);
            if (list == null)
            {
                msg = "暂无该库存的单品明细";
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            //排序+过滤过期药品
            List<Indetail> sortList = null;// SortDate(list);
            if (sortList == null)
            {
                msg = "暂无未过期的单品明细";
                totalPage = 0;
                currentPage = -1;
                return null;
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

        static private List<Indetail> SortDate(List<Indetail> indetailList)
        {

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime nowdate = Convert.ToDateTime(date);
            int m = 0;
            DateTime tempdate;
            for (int i = 0; i < indetailList.Count; i++)
            {
                if (Convert.ToDateTime(indetailList[i].batchNum) <= nowdate)
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
                tempdate = Convert.ToDateTime(indetailList[i].batchNum);
                for (int j = i + 1; j < indetailList.Count; j++)
                {
                    DateTime indetaildt = Convert.ToDateTime(indetailList[j].batchNum);
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
        static private List<Indetail> Swap(List<Indetail> indetailList, int m, int i)
        {
            Indetail t;
            t = indetailList[m];
            indetailList[m] = indetailList[i];
            indetailList[i] = t;
            return indetailList;
        }
        //出库
        static public bool OutWarehouse(int indetailId, int outNum, string userNum, out string msg)
        {
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
            Outflow outflow = new Outflow(stock.cagNum, stock.storeID, date, userNum, outNum, indetail.price, indetail.batchNum, "正常出库");
            if (indetail.quantity == 0)
            {
                if (!(IndetailDAL.Delete(indetailId, out msg)))
                {
                    msg = "单品明细删除失败";
                    return false;
                }
                if (!(StockDAL.Update(stock, out msg) && OutflowDAL.Add(outflow, out msg)))
                {
                    msg = "出库失败";
                    return false;
                }
            }
            else
               if (!(IndetailDAL.Update(indetail, out msg) && StockDAL.Update(stock, out msg) && OutflowDAL.Add(outflow, out msg)))
            {
                msg = "出库失败";
                return false;
            }
            return true;
        }
    }
}