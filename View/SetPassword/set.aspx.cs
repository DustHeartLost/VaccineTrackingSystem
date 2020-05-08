using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.SetPassword
{
    public partial class set : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='Login/Login.aspx'</script>");
        }

        [WebMethod]
        public static string SetNewPassword(string temp)
        {
            string msg;
            Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
            string userName = user["userName"].ToString();
            string passwordMD = Models.BLL.LoginManage.GenerateMD5(temp);
            return Models.BLL.UserManage.UpdateByOther(userName, passwordMD, out msg)? JsonConvert.SerializeObject(new Packet(200, "修改成功")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}  