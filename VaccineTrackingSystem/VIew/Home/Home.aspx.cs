using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.VIew.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel[] panels = new Panel[10];
            panels[0] = Panel1;
            panels[1] = Panel2;
            panels[2] = Panel3;
            panels[3] = Panel4;
            panels[4] = Panel5;
            panels[5] = Panel6;
            panels[6] = Panel7;
            panels[7] = Panel8;
            panels[8] = Panel9;
            panels[9] = Panel10;
            Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
            if (user == null)
            {
                Response.Write("<script>alert('登录信息过期，请重新登录');location.href='../Login/Login.aspx'</script>");
                return;
            }
            userName = user["name"].ToString();
            char[] temp = user["authority"].ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                panels[i].Visible = temp[i].Equals('1');
            }
        }
        [System.Web.Services.WebMethod]
        public static  string GetUserName()
        {
            if (userName != null)
                return JsonConvert.SerializeObject(userName);
            return null;
        }


        [System.Web.Services.WebMethod]
        public static string LoginOut()
        {
            HttpContext.Current.Session["user"] = null;
            HttpContext.Current.Session.Remove("user");
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.User = null;
            System.Web.Security.FormsAuthentication.SignOut();
            userName = null;
            return JsonConvert.SerializeObject(new Packet(200, "退出登录"));
        }
        protected static string userName=null;
    }
}
