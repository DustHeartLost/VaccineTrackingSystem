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

        static public bool UpdateByOther(string userName, string password, out string msg)
        {
            return UserDAL.UpdateByName(userName, password, out msg);
        }

        static public User Query(string num, out string msg)
        {
            return UserDAL.Query(num, out msg);
        }
        static public List<User> QueryAll(out string msg)
        {
            return UserDAL.QueryAll(out msg);
        }

    }
}