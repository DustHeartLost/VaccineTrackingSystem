using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class StoreManage
    {
        static public bool Add(Storeroom storeroom, out string msg)
        {
            if (StoreroomDAL.Add(storeroom, out msg))
                return true;
            return false;
        }
        static public bool Update(Storeroom storeroom, out string msg)
        {
            if (StoreroomDAL.Update(storeroom, out msg))
                return true;
            return false;
        }
        static public Storeroom Query(int id, string msg)
        {
            if (StoreroomDAL.Query(id, out msg) == null)
                return null;
            return StoreroomDAL.Query(id, out msg);
        }
        static public List<Storeroom> QueryAll(string msg)
        {
            if (StoreroomDAL.QueryAll(out msg) == null)
                return null;
            return StoreroomDAL.QueryAll(out msg);
        }

    }
}