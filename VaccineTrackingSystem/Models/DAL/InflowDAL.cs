using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.DAL
{
    public class InflowDAL
    {
        static public bool Add(Inflow inflow, String msg)
        {
            return true;
        }
        static public Inflow Query(int id, String msg)
        {
            return null;
        }
        static public List<Inflow> QueryAll(String msg)
        {
            return null;
        }
        static public bool Update(Inflow inflow, String msg)
        {
            return true;
        }

    }
}