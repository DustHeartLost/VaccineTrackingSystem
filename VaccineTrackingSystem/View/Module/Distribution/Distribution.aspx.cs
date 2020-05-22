using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models.BLL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Distribution
{
    public partial class Distribution : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;
        protected static Dictionary<string, int> storerooms;
        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
            storerooms = StoreManage.GetStoreroom();
        }

        [WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string jsonData = UserManage.QueryUserStoreroom(-1,ref totalPage, ref currentPage, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData = UserManage.QueryUserStoreroom(-1, ref totalPage, ref currentPage, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = UserManage.QueryUserStoreroom(-1, ref totalPage, ref currentPage, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [WebMethod]
        public static string Update(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg; 
            int storeId = storerooms[jo["storeName"].ToString()];
            return UserManage.UpdateUserStoreroom((int)jo["id"], storeId, out msg) ? JsonConvert.SerializeObject(new Packet(200, "修改成功")) : JsonConvert.SerializeObject(new Packet(202, msg));
        }

        [WebMethod]
        public static string GetData()
        {
            if (storerooms == null || storerooms.Count == 0) return JsonConvert.SerializeObject(new Packet(201, "暂无库房,请增加后刷新重试"));
            return JsonConvert.SerializeObject(new Packet(200, JsonConvert.SerializeObject(storerooms.Keys)));
        }

    }
}