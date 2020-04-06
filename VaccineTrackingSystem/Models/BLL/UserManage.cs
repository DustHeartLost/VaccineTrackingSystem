using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class UserManage
    {
        static public bool Add(User user, string msg)
        {
            if (UserDAL.Add(user, msg))
                return true;
            return false;
        }
     
        static public bool Update(User user,string msg)
        {
            if (UserDAL.Update(user, msg))
                return true;
            return false;
        }
        static public User Query(string num, string msg)
        {
            if (UserDAL.Query(num, msg) == null)
                return null;
            return UserDAL.Query(num, msg);
        }
        static public List<User> QueryAll(string msg)
        {
            if (UserDAL.QueryAll(msg) == null)
                return null;
            return UserDAL.QueryAll(msg);
        }

    }
}