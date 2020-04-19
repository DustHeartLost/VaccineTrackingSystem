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
        static public string Query(string num, out string msg)
        {
            List<Apartment> apartments = new List<Apartment>();
            Apartment apartment = ApartmentDAL.Query(num, out msg);
            if (apartment != null)
                apartments.Add(apartment);
            else
                return null;
            return JsonConvert.SerializeObject(apartments);
        }
        static public string QueryAll(out string msg,ref int totalPage, ref int currentPage)
        {
            List<Apartment> list = ApartmentDAL.QueryAll(out msg);
            if (list == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            totalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --totalPage;
            if (currentPage < totalPage)
                ++currentPage;
            try
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, list.Count - currentPage * 10));
            }
        }

    }
}