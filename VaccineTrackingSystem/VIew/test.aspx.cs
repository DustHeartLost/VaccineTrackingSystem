using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models;
using VaccineTrackingSystem.Models.DAL;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int zz=(int)SQL.getData("select * from [Table]").GetValue(0);
            Label1.Text = zz.ToString();
            Button1.Text = zz.ToString();
        }
    }
}