using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Inflow
{
    public partial class Inflow : System.Web.UI.Page
    {
        private static int store;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
            else
            {
                Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
                try {
                    store = int.Parse(user["storeID"]);
                }
                catch { 
                    Response.Write("<script language='javascript'>alert('您没有绑定的仓库');location.href='../../Home/Home.aspx'</script>");
                };
            }
        }

         
        [System.Web.Services.WebMethod]
        public static string Insert(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
            int storeId = int.Parse(user["storeID"]);
            string nowTime= DateTime.Now.ToString("yyyy-MM-dd");
            string userNum = user["num"];
            int quantity= int.Parse(jo["quantity"].ToString());
            decimal price = decimal.Parse(jo["price"].ToString());
            Models.Inflow inflow= new Models.Inflow(jo["cagNum"].ToString(), storeId, nowTime, userNum, quantity, price, jo["batchNum"].ToString());
            return Models.BLL.InflowManage.InWarehouse(inflow, out msg) ? JsonConvert.SerializeObject(new Packet(200, "入库成功")) : JsonConvert.SerializeObject(new Packet(203, msg));
        }
         
    }
}