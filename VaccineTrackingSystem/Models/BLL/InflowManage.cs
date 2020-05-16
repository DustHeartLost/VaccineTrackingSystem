﻿using Newtonsoft.Json;
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
            if (!InflowDAL.Add(inflow, out msg))
            {
                return false;
            }
            if (StockDAL.QueryByCagNum(inflow.cagNum, inflow.storeID, out msg) == null)
            {
                Stock stock = new Stock(inflow.cagNum, inflow.storeID, 0, 0);
                if (!StockDAL.Add(stock, out msg))
                {
                    msg = "库存记录增加失败";
                    return false;
                }
            }
            Stock s = StockDAL.QueryByCagNum(inflow.cagNum, inflow.storeID, out msg);
            if (s == null)
            {
                msg = "未查询到库存记录";
                return false;
            }
            s.quantity += inflow.quantity;
            s.money = s.money + inflow.quantity * inflow.price;
            if (!StockDAL.Update(s, out msg))
            {
                msg = "库存记录更新失败";
                return false;
            }
            //单品明细表更新

            //if (IndetailDAL.Query(s.id, inflow.batchNum, inflow.date, inflow.price,inflow.batchNum2,inflow.suppliers, out msg) == null)
            //{
                Indetail indetail = new Indetail(s.id, inflow.batchNum, inflow.date, inflow.quantity, inflow.price,inflow.batchNum2,inflow.suppliers,inflow.notes);
                if (!IndetailDAL.Add(indetail, out msg))
                {
                    msg = "单品明细表增加记录失败";
                    return false;
                }
            //}
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
            return true;
        }
    }
}