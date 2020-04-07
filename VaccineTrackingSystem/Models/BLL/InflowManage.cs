using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class InflowManage
    {

        static public bool InWarehouse(Inflow inflow, out string msg)
        {
            msg = null;
            return true;
        }


    }
}