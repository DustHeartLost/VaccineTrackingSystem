using Newtonsoft.Json;
using System;
using System.Web.Services;
using VaccineTrackingSystem.Models.BLL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.StockSearch
{
    public partial class StockSearch : System.Web.UI.Page
    {
        protected static int storeID = -1;
        protected static int totalPage;
        protected static int currentPage;
        protected static int states;

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            states =0;
        }
        [WebMethod]
        public static string Controller(int state, string data)
        {
            if (state != states)
            {
                totalPage = 0;
                currentPage = -1;
            }
            states = state;
            string temp = "";
            switch (state)
            {
                case 0: temp = precise(data); break;
           
            }
            return temp;
        }
        public static string precise(string temp) {
            string msg;
            decimal money=0;
            string data=StockManage.Query(storeID, temp.ToString(),out msg,ref money, ref totalPage, ref currentPage);
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        
        [WebMethod]
        public static string GetDown(string temp)
        {
            string data = "";
            string msg="";
            decimal money = 0;
            switch (states)
            {
                case 0: data = StockManage.Query(storeID, temp.ToString(), out msg, ref money, ref totalPage, ref currentPage); break;
            }
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetUp(string temp)
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string data = "";
            string msg = "";
            decimal money = 0;
            switch (states)
            {
                case 0: data = StockManage.Query(storeID, temp, out msg, ref money, ref totalPage, ref currentPage); break;
            }
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}