using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        public string GetDown()
        {
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage+1}+{currentPage+1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        public string GetUp()
        {
            if (currentPage == -1) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage+1}+{currentPage+1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [System.Web.Services.WebMethod]
        public static string Update(string temp) {
            JObject jo =(JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            Models.Role role = new Models.Role((int)jo["id"],jo["name"].ToString(),jo["authority"].ToString(), jo["note"].ToString());
            return Models.BLL.RoleManage.Update(role, out msg) ? JsonConvert.SerializeObject(new Packet(200, "修改成功")):JsonConvert.SerializeObject(new Packet(202, msg));
        }
    }
}