using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.DAL
{
    public class RoleDAL
    {
        static public bool Add(Role role, string msg)
        {
            return true;
        }
        static public bool Delete(int id, string msg)
        {
            return true;
        }
        static public bool Update(Role role,string msg)
        {
            return true;
        }
        static public Role Query(string name, string msg)
        {
            return null;
        }
        static public List<Role> QueryAll(string msg) 
        {
            return null;
        }

    }
}