using System;
using System.Web;
using VaccineTrackingSystem.Models.BLL;

namespace VaccineTrackingSystem.VIew.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Write(DateTime.Now.ToString("yyyyMMdd"));
            string dateString = "20200603";

            DateTime dt = DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            System.Diagnostics.Debug.Write(dt);
            //char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            //string msg = new string(letters);
            /**
             * Apartment apartment = new Apartment("#XNJD", "name", "hdb");
            char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            string msg = new string(letters);

            if (ApartmentDAL.Add(apartment, msg))
                System.Diagnostics.Debug.Write("ok");
            else
            {
                System.Diagnostics.Debug.Write("no" + msg);
            }
            System.Diagnostics.Debug.Write("###############################");
              **/
            /**if (ApartmentDAL.Delete(5, msg))
                System.Diagnostics.Debug.Write("ok");
            else
            {
                System.Diagnostics.Debug.Write("no");
            }
            System.Diagnostics.Debug.Write("###############################");**/
            /**Apartment apartment = new Apartment(6,"wy", "name", "wond");
            if (ApartmentDAL.Update(apartment, msg))
                System.Diagnostics.Debug.Write("ok");
            else
            {
                System.Diagnostics.Debug.Write("no");
            }
            System.Diagnostics.Debug.Write("###############################");*/

            //List<Apartment> list = ApartmentDAL.QueryAll(msg);
            //System.Diagnostics.Debug.Write(list.First().name);
            //System.Diagnostics.Debug.Write("###############################");

        }

        protected void submit(object sender, EventArgs e)
        {
            string msg;
            if (LoginManage.Login(Username.Text, Password.Text, out msg))
            {
                if (Password.Text=="123456")
                    Response.Redirect("../SetPassword/set.aspx");
                    //Response.Redirect("../Module/Inflow/Inflow.aspx");
                else
                    Response.Redirect("../Home/Home.aspx");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('账号或密码输入错误')</script>");
            }
        }
    }
}