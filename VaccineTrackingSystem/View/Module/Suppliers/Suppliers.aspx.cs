using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Suppliers
{
    public partial class Suppliers : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
        }

        [System.Web.Services.WebMethod]
        public static string GetALL()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            string msg;
            string jsonData = Models.BLL.SupplierManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetDown()
        {
            string msg;
            string jsonData = Models.BLL.SupplierManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string msg;
            string jsonData = Models.BLL.SupplierManage.QueryAll(out msg, ref totalPage, ref currentPage);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [System.Web.Services.WebMethod]
        public static string Update(string temp)
        {
            Models.Entity.Suppliers suppliers = JsonConvert.DeserializeObject<Models.Entity.Suppliers>(temp);
            string msg;
            return Models.BLL.SupplierManage.Update(suppliers, out msg) ? JsonConvert.SerializeObject(new Packet(200, "修改成功")) : JsonConvert.SerializeObject(new Packet(202, msg));
        }

        [System.Web.Services.WebMethod]
        public static string Insert(string temp)
        {
            Models.Entity.Suppliers suppliers = JsonConvert.DeserializeObject<Models.Entity.Suppliers>(temp);
            string msg;
            return Models.BLL.SupplierManage.Add(suppliers, out msg) ? JsonConvert.SerializeObject(new Packet(200, "插入成功")) : JsonConvert.SerializeObject(new Packet(203, msg));
        }


        [System.Web.Services.WebMethod]
        public static string SearchCon(string temp)
        {
            string msg;
            totalPage = 0;
            currentPage = 0;
            string t = "%";
            for (int i = 0; i < temp.Length; i++)
                t += temp[i] + "%";
            string jsonData = Models.BLL.SupplierManage.Query(t, out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string DestoryRecord(string temp)
        {
            List<int> list = JsonConvert.DeserializeObject<List<int>>(temp);
            string msg;
            return Models.BLL.SupplierManage.Destory(list, out msg) ? JsonConvert.SerializeObject(new Packet(200, Models.BLL.SupplierManage.QueryAll(out msg, ref totalPage, ref currentPage), $"{totalPage + 1}+{currentPage + 1}")) : JsonConvert.SerializeObject(new Packet(202, msg));
        }
    }
}