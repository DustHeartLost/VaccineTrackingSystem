using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class StoreManage
    {
        static public bool Add(Storeroom storeroom,string msg)
        {
            if (StoreroomDAL.Add(storeroom, msg))
                return true;
            return false;
        }
        static public bool Update(Storeroom storeroom,string msg)
        {
            if (StoreroomDAL.Update(storeroom, msg))
                return true;
            return false;
        }
        static public Storeroom Query(int id, string msg)
        {
            if (StoreroomDAL.Query(id, msg) == null)
                return null;
            return StoreroomDAL.Query(id, msg);
        }
        static public List<Storeroom> QueryAll(string msg)
        {
            if (StoreroomDAL.QueryAll(msg) == null)
                return null;
            return StoreroomDAL.QueryAll(msg);
        }

    }
}