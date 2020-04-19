﻿using Newtonsoft.Json;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class TableManage
    {
        static public string queryAllInflow(int storeID, ref int inflowTotalPage, ref int inflowCurrentPage,  out string msg, out decimal money)
        {
            money = 0m;
            List<Dictionary<string,string>> list = InflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null)
            {
                inflowTotalPage = 0;
                inflowCurrentPage = -1;
                return null;
            }
            msg = null;
            foreach (Dictionary<string, string> d in list) {
                money += decimal.Parse(d["price"] )* decimal.Parse(d["quantity"]);
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

    }
}