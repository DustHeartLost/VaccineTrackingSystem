using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class TableManage
    {
        static public List<Inflow> queryAllInflow(int storeID, out string msg, out decimal money)
        {
            money = 0m;
            List<Inflow> list = InflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null) return null;
            msg = null;
            foreach (Inflow inflow in list)
            {
                money += inflow.quantity * inflow.price;
            }
            return list;
        }

        static public List<Outflow> queryAllOutflow(int storeID, out string msg, out decimal money)
        {
            money = 0m;
            List<Outflow> list = OutflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null) return null;
            msg = null;
            foreach (Outflow outflow in list)
            {
                money += outflow.price * outflow.quantity;
            }
            return list;
        }

    }
}