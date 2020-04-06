using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.DAL
{
    public class IndetailDAL
    {
        static public bool Add(Indetail indetail, String msg)
        {
            return true;
        }
        static public Indetail Query(int id, String msg)
        {
            return null;
        }
        static public List<Indetail> QueryAll(String msg)
        {
            return null;
        }
        static public bool Update(Indetail indetail, String msg)
        {
            return true;
        }
        static public bool Delete(int id, String msg)
        {
            return true;
        }

    }
}