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
        static public string QueryAll(out string msg,ref int totalPage,ref int currentPage)
        {
            List<Role>list=RoleDAL.QueryAll(out msg);
            if (list == null) {
                totalPage = 0;
                currentPage = -1;
                return null;
            } 
            totalPage = (int)System.Math.Floor((decimal)(list.Count/10));
            currentPage=currentPage+1;
            if (currentPage > totalPage) return JsonConvert.SerializeObject(list.GetRange(--currentPage, list.Count - currentPage * 10));
            try{ 
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, 10));
            }
            catch {
                return JsonConvert.SerializeObject(list.GetRange(currentPage,list.Count-currentPage*10));
            }
        }


    }
}