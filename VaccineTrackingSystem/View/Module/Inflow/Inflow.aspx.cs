using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using VaccineTrackingSystem.Models.BLL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Inflow
{
    public partial class Inflow : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;
        private static int storeId;
        private static string userNum;
        protected static Dictionary<string, string> category;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
            else
            {
                Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
                try {
                    storeId = int.Parse(user["storeID"]);
                }
                catch { 
                    Response.Write("<script language='javascript'>alert('您没有绑定的仓库');location.href='../../Home/Home.aspx'</script>");
                };
                userNum = user["num"];
                category = CategoryManage.GetCate();
            }
        }

        [WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string nowTime= DateTime.Now.ToString("yyyy-MM-dd");
            string jsonData = Models.BLL.InflowManage.QueryTodayRecoder(storeId, nowTime, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetDown()
        {
            string msg;
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd");
            string jsonData = Models.BLL.InflowManage.QueryTodayRecoder(storeId, nowTime, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd");
            string jsonData = Models.BLL.InflowManage.QueryTodayRecoder(storeId, nowTime, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

    }
}