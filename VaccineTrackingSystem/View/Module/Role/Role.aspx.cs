using Newtonsoft.Json;
using System;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.VIew.Module.Role
{
    public partial class Role : System.Web.UI.Page
    {
        protected int totalPage;
        protected int currentPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
        }

        public string GetALL()
        {
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        public string GetDown()
        {
            currentPage++;
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        public string GetUp()
        {
            if (currentPage <= -1) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage--;
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}