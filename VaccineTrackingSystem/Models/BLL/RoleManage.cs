using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class RoleManage
    {
        static public bool Add(Role role, out string msg)
        {
            if (RoleDAL.Add(role, out msg))
                return true;
            return false;
        }

        static public bool Update(Role role, out string msg)
        {
            if (RoleDAL.Update(role, out msg))
                return true;
            return false;
        }
        static public Role Query(string name, out string msg)
        {
            if (RoleDAL.Query(name, out msg)==null)
                return null;
            return RoleDAL.Query(name, out msg);
        }
        static public List<Role> QueryAll(out string msg)
        {
            if (RoleDAL.QueryAll(out msg) == null)
                return null;
            return RoleDAL.QueryAll(out msg);
        }


    }
}