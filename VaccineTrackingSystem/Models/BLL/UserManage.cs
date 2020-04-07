using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class UserManage
    {
        static public bool Add(User user, out string msg)
        {
            if (UserDAL.Add(user, out msg))
                return true;
            return false;
        }
     
        static public bool Update(User user,string msg)
        {
            if (UserDAL.Update(user, out msg))
                return true;
            return false;
        }
        static public User Query(string num, string msg)
        {
            if (UserDAL.Query(num, out msg) == null)
                return null;
            return UserDAL.Query(num,out msg);
        }
        static public List<User> QueryAll(out string msg)
        {
            if (UserDAL.QueryAll(out msg) == null)
                return null;
            return UserDAL.QueryAll(out msg);
        }

    }
}