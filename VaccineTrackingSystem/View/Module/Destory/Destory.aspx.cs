using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Destory
{
    public partial class Destory : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;
        protected static int stockID = 3;
        protected static string num="123";//员工编号

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            //stockID = int.Parse(Request.QueryString["stockID"]);
        }

        [WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string jsonData = JsonConvert.SerializeObject(Models.BLL.DestoryManage.Query(stockID, ref totalPage, ref currentPage, out msg));
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData = JsonConvert.SerializeObject(Models.BLL.DestoryManage.Query(stockID, ref totalPage, ref currentPage, out msg));
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = JsonConvert.SerializeObject(Models.BLL.DestoryManage.Query(stockID, ref totalPage, ref currentPage, out msg));
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string DestoryRecord()
        {
            string msg1;
            List<Indetail> list = Models.BLL.DestoryManage.Query(stockID, ref totalPage, ref currentPage, out msg1);
            if (list == null) {
                return JsonConvert.SerializeObject(new Packet(201, msg1));
            }
            string msg;
            return Models.BLL.DestoryManage.Destory(list, num, out msg)? JsonConvert.SerializeObject(new Packet(200,null)): JsonConvert.SerializeObject(new Packet(202, msg));
        }

    }
}