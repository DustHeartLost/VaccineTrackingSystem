using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class AprtManage
    {
        static public bool Add(Apartment apartment,string msg)
        {
            if(ApartmentDAL.Add(apartment, msg))
                return true;
            return false;
        }
        static public bool Update(Apartment apartment,string msg)
        {
            if (ApartmentDAL.Update(apartment, msg))
                return true;
            return false;
        }
        static public Apartment Query(string num, string msg)
        {
            if (ApartmentDAL.Query(num, msg) == null)
                return null;
            return ApartmentDAL.Query(num, msg);
        }
        static public List<Apartment> QueryAll(string msg)
        {
            if (ApartmentDAL.QueryAll(msg) == null)
                return null;
            return ApartmentDAL.QueryAll(msg);
        }

    }
}