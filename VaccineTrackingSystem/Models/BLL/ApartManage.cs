﻿using Newtonsoft.Json;
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
        static public string Query(string name, out string msg)
        {
            List<Apartment> apartments = new List<Apartment>();
            apartments = ApartmentDAL.Query(name, out msg);
            if (apartments == null) return null;
            return JsonConvert.SerializeObject(apartments);
        }
        static public string QueryAll(out string msg, ref int totalPage, ref int currentPage)
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

        static public Dictionary<string, int> GetApartment()
        {
            return ApartmentDAL.GetApartment();
        }

    }
}