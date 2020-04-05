using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.VIew.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            string msg = new string(letters);
            /** **/
            Role  role = new Role("#XNJD", "name", "hdb");
            if (RoleDAL.Add(role, msg))
                System.Diagnostics.Debug.Write("ok");
            else
            {
                System.Diagnostics.Debug.Write("no" + msg);
            }
            System.Diagnostics.Debug.Write("###############################");
             
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
            
            List<Apartment> list = ApartmentDAL.QueryAll(msg);
            System.Diagnostics.Debug.Write(list.First().name);
            System.Diagnostics.Debug.Write("###############################");

        }

        protected void Button_Click(object sender, EventArgs e)
        {
          
        }
    }
}