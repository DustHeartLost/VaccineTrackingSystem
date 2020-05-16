using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Outflow
{
    public partial class Outflow : System.Web.UI.Page
    {
        private static int storeId;
        protected static int totalPage;
        protected static int currentPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
            Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;

            try
            {
                storeId = int.Parse(user["storeID"]);
            }
            catch
            {
                storeId = -1;
                Response.Write("<script language='javascript'>alert('您没有绑定的仓库');location.href='../../Home/Home.aspx'</script>");
            };
        }

        [System.Web.Services.WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string jsonData = Models.BLL.OutflowManage.QueryStockByStoreID(storeId, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData = Models.BLL.OutflowManage.QueryStockByStoreID(storeId, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = Models.BLL.OutflowManage.QueryStockByStoreID(storeId, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }


        [WebMethod]
        public static string SearchCon(string temp)
        {
            string msg;
            string t = "%";
            for (int i = 0; i < temp.Length; i++)
                t += temp[i] + "%";
            string jsonData = Models.BLL.OutflowManage.QueryByCagName(t,storeId, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}