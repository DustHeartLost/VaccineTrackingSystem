using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class TableManage
    {
        static public List<Inflow> queryAllInflow(int storeID, out string msg)
        {
            List<Inflow> list = InflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null)
            {
                return null;
            }
            msg = null;
            return list;
        }

        static public List<Outflow> queryAllOutflow(int storeID, out string msg)
        {
            List<Outflow> list = OutflowDAL.QueryAllByStoreID(storeID, out msg);
            if (list == null)
            {
                return null;
            }
            msg = null;
            return list;
        }

    }
}