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
        protected void Page_Load(object sender, EventArgs e)
        {
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

        [WebMethod]
        public static string SearchCon(string temp)
        {
            string msg;
            string jsonData = Models.BLL.OutflowManage.QueryStrock(temp,storeId, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}