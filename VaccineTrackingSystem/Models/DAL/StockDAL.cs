using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.DAL
{
    public class StockDAL
    {
        static public bool Add(Stock stock, String msg)
        {
            return true;
        }
        static public Stock Query(string num, String msg)
        {
            return null;
        }
        static public List<Stock> QueryAll(String msg)
        {
            return null;
        }
        static public bool Update(Stock stock, String msg)
        {
            return true;
        }

    }
}