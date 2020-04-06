using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class RoleManage
    {
        static public bool Add(Role role,string msg)
        {
            if (RoleDAL.Add(role, msg))
                return true;
            return false;
        }

        static public bool Update(Role role,string msg)
        {
            if (RoleDAL.Update(role, msg))
                return true;
            return false;
        }
        static public Role Query(String name, string msg)
        {
            if (RoleDAL.Query(name, msg)==null)
                return null;
            return RoleDAL.Query(name, msg);
        }
        static public List<Role> QueryAll(String msg)
        {
            if (RoleDAL.QueryAll(msg) == null)
                return null;
            return RoleDAL.QueryAll(msg);
        }


    }
}