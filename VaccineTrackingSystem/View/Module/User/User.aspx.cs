using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using VaccineTrackingSystem.Models.BLL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.User
{
    public partial class User : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;
        protected static Dictionary<string ,int> roles;
        protected static Dictionary<string, int> apartment;
        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
            roles = RoleManage.GetRole();
            apartment = ApartManage.GetApartment();
        }

        [WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string jsonData = UserManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData =UserManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = UserManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [WebMethod]
        public static string Update(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            string password;
            if (jo["password"].ToString().Equals("******")) password = null;
            else password= LoginManage.GenerateMD5(jo["password"].ToString());
            int apartID = apartment[jo["apartID"].ToString()];
            int roleID = roles[jo["roleID"].ToString()];
            Models.User user = new Models.User((int)jo["id"], jo["userName"].ToString(), password, apartID, jo["job"].ToString(), roleID, jo["num"].ToString(), jo["name"].ToString());
            return UserManage.Update(user, out msg) ? JsonConvert.SerializeObject(new Packet(200, "修改成功")) : JsonConvert.SerializeObject(new Packet(202, msg));
        }

        [WebMethod]
        public static string Insert(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            string password = LoginManage.GenerateMD5(jo["password"].ToString());
            int apartID = apartment[jo["apartID"].ToString()];
            int roleID = roles[jo["roleID"].ToString()];
            Models.User user = new Models.User((int)jo["id"], jo["userName"].ToString(), password, apartID, jo["job"].ToString(), roleID, jo["num"].ToString(), jo["name"].ToString());
            return UserManage.Add(user, out msg) ? JsonConvert.SerializeObject(new Packet(200, "插入成功")) : JsonConvert.SerializeObject(new Packet(203, msg));
        }
        [WebMethod]
        public static string SearchCon(string temp)
        {
           string t="%";
           for (int i = 0; i < temp.Length; i++)
                t += temp[i] + "%";
            string msg;
            totalPage = 0;
            currentPage = 0;
            string jsonData = UserManage.Query(t, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetData() {
            if (roles == null) return JsonConvert.SerializeObject(new Packet(201, "没有角色列表,请增加角色后刷新重试"));
            if (apartment == null) return JsonConvert.SerializeObject(new Packet(201, "没有机构列表,请增加机构后刷新重试"));
            return JsonConvert.SerializeObject(new Packet(200, JsonConvert.SerializeObject(roles.Keys),JsonConvert.SerializeObject(apartment.Keys)));
        }
        
    }
}