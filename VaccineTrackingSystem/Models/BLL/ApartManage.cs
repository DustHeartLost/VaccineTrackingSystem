using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class ApartManage
    {
        static public string Add(Apartment apartment, out string msg)
        {
            return JsonConvert.SerializeObject(ApartmentDAL.Add(apartment, out msg));
        }
        static public string  Update(Apartment apartment, out string msg)
        {
            return JsonConvert.SerializeObject(ApartmentDAL.Update(apartment, out msg));
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
                currentPage = 0;
                return null;
            }
            totalPage = (int)System.Math.Floor((decimal)(apartments.Count / 10));
            if(currentPage< totalPage)
            { 
                return JsonConvert.SerializeObject(apartments.GetRange(currentPage * 10, 10));
            }
            if (currentPage == totalPage)
            {
                return JsonConvert.SerializeObject(apartments.GetRange(totalPage*10, apartments.Count - totalPage * 10));
            }
            
            return null;
        }

    }
}