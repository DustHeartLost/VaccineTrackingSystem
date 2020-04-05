using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VaccineTrackingSystem.VIew.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel4.Visible = false;
            Panel3.Visible = false;
            Panel7.Visible = false;
        }
    }
}