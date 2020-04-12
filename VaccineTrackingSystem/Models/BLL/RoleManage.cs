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
        static public string Query(string name, out string msg)
        {
            List<Role> roles = new List<Role>();
            if (RoleDAL.Query(name, out msg) != null)
                roles.Add(RoleDAL.Query(name, out msg));
            else
               return null;
            return JsonConvert.SerializeObject(roles);
        }
        static public string QueryAll(out string msg,ref int totalPage,ref int currentPage)
        {
            List<Role>list=RoleDAL.QueryAll(out msg);
            if (list == null) {
                totalPage = 0;
                currentPage = -1;
                return null;
            } 
            totalPage = (int)System.Math.Floor((decimal)(list.Count/10));
            if (currentPage < totalPage) 
                ++currentPage;
            try {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, 10));
            } catch {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, list.Count - currentPage * 10));
            }            
        }
    }
}