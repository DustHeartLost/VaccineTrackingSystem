using Newtonsoft.Json;
using System;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Apartment
{
    public partial class Apartment : System.Web.UI.Page
    {
        protected int totalPage;
        protected int currentPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
        }

        public string GetTotal()
        {
            return (totalPage+1).ToString();
        }

        public string GetCurr()
        {
            return (currentPage+1).ToString();
        }

        public string GetALL()
        {
            string msg;
            string jsonData = Models.BLL.ApartManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? Newtonsoft.Json.JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        public string GetDown()
        {
            currentPage++;
            string msg;
            string jsonData = Models.BLL.ApartManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        public string GetUp()
        {
            if (currentPage <= -1) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage--;
            string msg;
            string jsonData = Models.BLL.ApartManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }


    }
}