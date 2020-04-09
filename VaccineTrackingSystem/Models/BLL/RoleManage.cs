using Newtonsoft.Json;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class RoleManage
    {
        static public bool Add(Role role, out string msg)
        {
            return RoleDAL.Add(role, out msg);
        }

        static public bool Update(Role role, out string msg)
        {
            return RoleDAL.Update(role, out msg);
        }
        static public Role Query(string name, out string msg)
        {
            return RoleDAL.Query(name, out msg);
        }
        static public string QueryAll(out string msg)
        {
            List<Role>list=RoleDAL.QueryAll(out msg);
            return list != null ? JsonConvert.SerializeObject(list) : null;
        }


    }
}