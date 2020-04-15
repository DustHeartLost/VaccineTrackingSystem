using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
        }

        [WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string jsonData = Models.BLL.UserManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData = Models.BLL.UserManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = Models.BLL.UserManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [WebMethod]
        public static string Update(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            string password = LoginManage.GenerateMD5(jo["password"].ToString());
            Models.User user = new Models.User((int)jo["id"], jo["userName"].ToString(), password, (int)jo["apartID"], jo["job"].ToString(), (int)jo["roleID"], jo["num"].ToString(), jo["name"].ToString());
            return Models.BLL.UserManage.Update(user, out msg) ? JsonConvert.SerializeObject(new Packet(200, "修改成功")) : JsonConvert.SerializeObject(new Packet(202, msg));
        }

        [WebMethod]
        public static string Insert(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            try {
                int x=(int)jo["apartID"];
            } catch {
                return JsonConvert.SerializeObject(new Packet(203, "关联机构只能为数字：机构的ID"));
            };
            try
            {
                int y=(int)jo["roleID"];
            }
            catch
            {
                return JsonConvert.SerializeObject(new Packet(203, "关联角色只能为数字：角色ID"));
            };
            string password = LoginManage.GenerateMD5(jo["password"].ToString());
            System.Diagnostics.Debug.Write(password);
            Models.User user = new Models.User(jo["userName"].ToString(), password, (int)jo["apartID"], jo["job"].ToString(), (int)jo["roleID"], jo["num"].ToString(), jo["name"].ToString());
            return Models.BLL.UserManage.Add(user, out msg) ? JsonConvert.SerializeObject(new Packet(200, "插入成功")) : JsonConvert.SerializeObject(new Packet(203, msg));
        }
        [WebMethod]
        public static string SearchCon(string temp)
        {
            string msg;
            totalPage = 0;
            currentPage = 0;
            string jsonData = Models.BLL.UserManage.Query(temp, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}