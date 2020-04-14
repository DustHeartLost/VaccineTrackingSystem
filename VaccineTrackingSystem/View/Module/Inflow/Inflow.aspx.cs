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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string GetStoreroom()
        {
            string msg="暂未绑定库房";
            Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
            string store =user["storeID"].ToString();
            if (store != null && store != "")
                return JsonConvert.SerializeObject(new Packet(200, store));
            else
                return JsonConvert.SerializeObject(new Packet(201, msg));
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
            decimal price = Decimal.Parse(jo["price"].ToString());
            Models.Inflow inflow= new Models.Inflow(jo["cagNum"].ToString(), storeId, nowTime, userNum, quantity, price, jo["batchNum"].ToString());
            return Models.BLL.InflowManage.InWarehouse(inflow, out msg) ? JsonConvert.SerializeObject(new Packet(200, "入库成功")) : JsonConvert.SerializeObject(new Packet(203, msg));
        }
         
    }
}