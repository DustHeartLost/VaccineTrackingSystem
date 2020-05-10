using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Alert
{
    public partial class Alert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
        }

        [WebMethod]
        public static string GetALL()
        {
            string msg;
            string jsonData = Models.BLL.AlertManage.QueryAll(out msg);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData)) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
       

        [WebMethod]
        public static string AddRecord(string data)
        {
            string msg;
            Models.Entity.Alert alert = null;
            try
            {
                alert = JsonConvert.DeserializeObject<Models.Entity.Alert>(data);
            }
            catch
            {
                return JsonConvert.SerializeObject(new Packet(202, "剩余天数格式为数字,例：30"));
            }
            if (!IsHexadecimal(alert.color)) return JsonConvert.SerializeObject(new Packet(202, "颜色数值为16进制数"));
            return Models.BLL.AlertManage.Add(alert, out msg) ? JsonConvert.SerializeObject(new Packet(200, "插入成功")) : JsonConvert.SerializeObject(new Packet(203, msg));
        }

        [WebMethod]
        public static string Update(string data)
        {
            string msg;
            Models.Entity.Alert alert=null;
            try
            {
                alert = JsonConvert.DeserializeObject<Models.Entity.Alert>(data);
            }
            catch {
                return JsonConvert.SerializeObject(new Packet(202, "剩余天数格式为数字,例：30"));
            }
            if(!IsHexadecimal(alert.color)) return JsonConvert.SerializeObject(new Packet(202, "颜色数值为16进制数"));
            return Models.BLL.AlertManage.Update(alert, out msg) ? JsonConvert.SerializeObject(new Packet(200, "修改成功")) : JsonConvert.SerializeObject(new Packet(202, msg));
        }

        private static bool IsHexadecimal(string str)
        {
            if (str == "")
                return false;
            const string PATTERN = @"[A-Fa-f0-9]+$";
            bool sign = false;
            for (int i = 0; i < str.Length; i++)
            {
                sign = System.Text.RegularExpressions.Regex.IsMatch(str[i].ToString(), PATTERN);
                if (!sign)
                {
                    return sign;
                }
            }
            return sign;
        }

        [System.Web.Services.WebMethod]
        public static string DestoryRecord(string temp)
        {
            List<int> list = JsonConvert.DeserializeObject<List<int>>(temp);
            string msg;
            return Models.BLL.AlertManage.Destory(list, out msg) ? JsonConvert.SerializeObject(new Packet(200, Models.BLL.AlertManage.QueryAll(out msg))) : JsonConvert.SerializeObject(new Packet(202, msg));
        }
    }
}