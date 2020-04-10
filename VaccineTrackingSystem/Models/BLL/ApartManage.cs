using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.UI.WebControls;
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
        static public string QueryAll(out string msg,ref int totalPage, ref int currentPage)
        {
            List<Apartment> apartments= ApartmentDAL.QueryAll(out msg);
            if (apartments == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            totalPage = (int)System.Math.Floor((decimal)(apartments.Count / 10));
            currentPage = currentPage + 1;
            if (currentPage > totalPage) return JsonConvert.SerializeObject(apartments.GetRange(--currentPage, apartments.Count - currentPage * 10));
            try
            {
                return JsonConvert.SerializeObject(apartments.GetRange(currentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(apartments.GetRange(currentPage, apartments.Count - currentPage * 10));
            }
        }

    }
}