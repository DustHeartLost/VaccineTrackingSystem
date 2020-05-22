using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.Models.BLL
{
    public class LoginManage
    {
        public static bool Login(string username, string password, out string msg)
        {
            password = GenerateMD5(password);
            Dictionary<string, string> dictionary = UserDAL.QueryByUserName(username, password, out msg);
            if (dictionary == null) return false;
            if (dictionary["authority"].Substring(4).Contains("1"))
            {
                Storeroom storeroom = StoreroomDAL.QueryByUserNum(dictionary["num"]);
                if (storeroom != null)
                {
                    dictionary.Add("storeID", storeroom.id.ToString());
                }
            }
            HttpContext.Current.Session["user"] = dictionary;
            return true;
        }
        //MD5加密算法
        public static string GenerateMD5(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(input);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                sb.Append(b.ToString("x2"));
            }

            //再次加密
            byte[] nbs = Encoding.UTF8.GetBytes(input);
            byte[] nhs = md5.ComputeHash(nbs);
            StringBuilder nsb = new StringBuilder();
            foreach (byte nb in nhs)
            {
                nsb.Append(nb.ToString("x2"));
            }
            return nsb.ToString();
        }
    }
}