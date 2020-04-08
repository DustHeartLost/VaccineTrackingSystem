using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class StoreManage
    {
        static public bool Add(Storeroom storeroom, out string msg)
        {
            return StoreroomDAL.Add(storeroom, out msg);
        }
        static public bool Update(Storeroom storeroom, out string msg)
        {
            return StoreroomDAL.Update(storeroom, out msg);
        }
        static public Storeroom Query(int id, out string msg)
        {
            return StoreroomDAL.Query(id, out msg);
        }
        static public List<Storeroom> QueryAll(out string msg)
        {
            return StoreroomDAL.QueryAll(out msg);
        }

    }
}