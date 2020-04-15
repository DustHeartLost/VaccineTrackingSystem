using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.Web.Services;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.VIew.Module.Role
{
    public partial class Role : System.Web.UI.Page
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
        [System.Web.Services.WebMethod]
        public static string GetALL()
        {
            if (currentPage !=-1) {
                currentPage--;
            }
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage+1}+{currentPage+1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [System.Web.Services.WebMethod]
        public static string Update(string temp) {
            JObject jo =(JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            Models.Role role = new Models.Role((int)jo["id"],jo["name"].ToString(),jo["authority"].ToString(), jo["note"].ToString());
            return Models.BLL.RoleManage.Update(role, out msg) ? JsonConvert.SerializeObject(new Packet(200, "修改成功")):JsonConvert.SerializeObject(new Packet(202, msg));
        }

        [System.Web.Services.WebMethod]
        public static string Insert(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            Models.Role role = new Models.Role(jo["name"].ToString(), jo["authority"].ToString(), jo["note"].ToString());
            return Models.BLL.RoleManage.Add(role, out msg) ? JsonConvert.SerializeObject(new Packet(200, "插入成功")) : JsonConvert.SerializeObject(new Packet(203, msg));
        }
    

        [WebMethod]
        public static string SearchCon(string temp)
        {
            string msg;
            totalPage = 0;
            currentPage = 0;
            string jsonData = Models.BLL.RoleManage.Query(temp,out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}