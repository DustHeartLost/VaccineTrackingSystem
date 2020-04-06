using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.BLL
{
    public class AprtManage
    {
        static public bool add(Apartment apartment,String msg)
        {
            return true;
        }
        static public bool delete(int id, String msg)
        {
            return true;
        }
        static public bool update(Apartment apartment,String msg)
        {
            return true;
        }
        static public Apartment query(String num, String msg)
        {
            return null;
        }
        static public List<Apartment> queryAll(String msg)
        {
            return null;
        }

    }
}