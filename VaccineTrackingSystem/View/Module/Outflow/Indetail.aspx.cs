using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Outflow
{

    public partial class Indetail : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;
        protected static int stockId;
        protected static string userNum;
        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
            userNum = user["num"].ToString();
            if (userNum == null || userNum == "")
            {
                Response.Write("<script language='javascript'>alert('登录过期')</script>");
                Response.Redirect("../../Login/Login.aspx");
            }

        }

        [System.Web.Services.WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string jsonData = Models.BLL.OutflowManage.QueryIndetail(stockId, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData = Models.BLL.OutflowManage.QueryIndetail(stockId, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = Models.BLL.OutflowManage.QueryIndetail(stockId, out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [System.Web.Services.WebMethod]
        public static string Update(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            int quantity;
            if (!int.TryParse(jo["quantity"].ToString(), out quantity)) { return JsonConvert.SerializeObject(new Packet(202, "出库数量格式错误，请输入数字")); }
            if (quantity <= 0) { return JsonConvert.SerializeObject(new Packet(203, "数量必须大于0")); }
            return Models.BLL.OutflowManage.OutWarehouse((int)jo["id"], quantity, userNum, out msg) ? JsonConvert.SerializeObject(new Packet(200, "出库成功")) : JsonConvert.SerializeObject(new Packet(202, msg));
        }

        [System.Web.Services.WebMethod]
        public static string setStockId(string temp)
        {
            if (temp == null || temp == "")
                return null;
            stockId = int.Parse(temp);
            return JsonConvert.SerializeObject(new Packet(200, "成功传入"));
        }
    }
}