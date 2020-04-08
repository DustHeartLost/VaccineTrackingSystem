using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class ApartManage
    {
        static public bool Add(Apartment apartment, out string msg)
        {
            if (ApartmentDAL.Add(apartment, out msg))
                return true;
            return false;
        }
        static public bool Update(Apartment apartment, out string msg)
        {
            if (ApartmentDAL.Update(apartment, out msg))
                return true;
            return false;
        }
        static public Apartment Query(string num, out string msg)
        {
            if (ApartmentDAL.Query(num, out msg) == null)
                return null;
            return ApartmentDAL.Query(num, out msg);
        }
        static public List<Apartment> QueryAll(out string msg)
        {
            if (ApartmentDAL.QueryAll(out msg) == null)
                return null;
            return ApartmentDAL.QueryAll(out msg);
        }

    }
}