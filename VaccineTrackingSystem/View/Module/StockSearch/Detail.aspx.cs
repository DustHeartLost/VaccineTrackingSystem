using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.StockSearch
{
    public partial class Detail : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;
        protected static int stockID=-1;
        protected static string information;

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            stockID = int.Parse(Request.QueryString["stockID"]);
            information = Request.QueryString["temp"];
        }

        [WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string jsonData = Models.BLL.StockManage.QueryInDetail(stockID, ref totalPage, ref currentPage,out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}+{information}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData = Models.BLL.StockManage.QueryInDetail(stockID, ref totalPage, ref currentPage, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}+{information}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = Models.BLL.StockManage.QueryInDetail(stockID, ref totalPage, ref currentPage, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}+{information}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}