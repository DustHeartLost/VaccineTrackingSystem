using Newtonsoft.Json;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class UserManage
    {
        static public bool Add(User user, out string msg)
        {
            return UserDAL.Add(user, out msg);
        }

        static public bool Update(User user, out string msg)
        {
            return UserDAL.Update(user, out msg);
        }
        static public string Query(string name, out string msg)
        {
            List<Dictionary<string, string>> list = UserDAL.Query(name,out msg);
            return list != null?JsonConvert.SerializeObject(list): null;
        }
        static public string QueryAll(out string msg, ref int totalPage, ref int currentPage)
        {
            List<Dictionary<string,string>> list = UserDAL.Query(null,out msg);
            if (list == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            totalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --totalPage;
            if (currentPage < totalPage)
                ++currentPage;
            try
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, list.Count - currentPage * 10));
            }
        }

        static public bool UpdateByOther(string userName, string password, out string msg)
        {
            return UserDAL.UpdateByName(userName, password, out msg);
        }

        static public Dictionary<string, string> GetUser()
        {
            return UserDAL.GetUser();
        }


        static public string QueryUserStoreroom(string name,ref int totalPage, ref int currentPage ,out string msg)
        {
            List<Dictionary<string, string>> list = UserDAL.QueryUserStoreroom(name, out msg);
            if (list == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            totalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --totalPage;
            if (currentPage < totalPage)
                ++currentPage;
            try
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, list.Count - currentPage * 10));
            }
        }

        static public bool UpdateUserStoreroom(int userId, int storeId, out string msg)
        {
            return UserDAL.UpdateUserStoreroom(userId,storeId, out msg);
        }
    }
}