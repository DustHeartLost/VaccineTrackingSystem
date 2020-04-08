using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class ApartManage
    {
        static public bool Add(Apartment apartment, out string msg)
        {
            return ApartmentDAL.Add(apartment, out msg);
        }
        static public bool Update(Apartment apartment, out string msg)
        {
            return ApartmentDAL.Update(apartment, out msg);
        }
        static public Apartment Query(string num, out string msg)
        {
            return ApartmentDAL.Query(num, out msg);
        }
        static public List<Apartment> QueryAll(out string msg)
        {
            return ApartmentDAL.QueryAll(out msg);
        }

    }
}