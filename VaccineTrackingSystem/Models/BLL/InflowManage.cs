using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class InflowManage
    {

        static public bool InWarehouse(Inflow inflow, String msg)
        {
            if (!InflowDAL.Add(inflow, msg))
                return false;
            if(StockDAL.Query(inflow.cagNum,msg)==null)
            {
                Stock stock = new Stock(inflow.cagNum, inflow.storeID, 0, 0);
                if (!StockDAL.Add(stock, msg))
                    return false;
            }
            Stock s = StockDAL.Query(inflow.cagNum, msg);
            if (s == null)
                return false;
            return true;

        }


    }
}