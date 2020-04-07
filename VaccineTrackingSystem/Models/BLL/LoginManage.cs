using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class LoginManage
    {
        public static bool Login(string username, string password,out string msg) {
            Dictionary<string, string> dictionary = UserDAL.QueryByUserName(username, password,out msg);
            if (dictionary == null) return false;
            if (dictionary["authority"].Substring(4).Contains("1")) {
                Storeroom storeroom = StoreroomDAL.QueryByUserNum(dictionary["num"]);
                if (storeroom != null) {
                    dictionary.Add("storeID", storeroom.id.ToString());
                }
            }
            HttpContext.Current.Session["user"] = dictionary;
            return true;
        }
    }
}