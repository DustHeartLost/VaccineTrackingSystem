using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models;
using VaccineTrackingSystem.Models.DAL;

namespace VaccineTrackingSystem.VIew.Home
{
    public partial class Home : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            string msg=new string(letters);

            /**  
            Category user = new Category("duofen", "多酚","治疗类","五道金口","规格","澳洲","dchuib");
            if (CategoryDAL.Add(user, msg))
                System.Diagnostics.Debug.Write("ok");
            else
            {
                System.Diagnostics.Debug.Write("no" + msg);
            }
            System.Diagnostics.Debug.Write("###############################");**/

            /**
            if (CategoryDAL.Delete(1, msg))
                System.Diagnostics.Debug.Write("ok");
            else
            {
                System.Diagnostics.Debug.Write("no");
            }
            System.Diagnostics.Debug.Write("###############################");**/
            /**
            Category category = new Category(2, "duoduo", "多酚", "治疗类", "五道金口", "规格", "澳洲", "dchuib");
            if (CategoryDAL.Update(category, msg))
                System.Diagnostics.Debug.Write("ok");
            else
            {
                System.Diagnostics.Debug.Write("no");
            }
            System.Diagnostics.Debug.Write("###############################");*/
            /**/
            List<Category> list = CategoryDAL.QueryAll(msg);
             System.Diagnostics.Debug.Write(list.First().spec);
             System.Diagnostics.Debug.Write("###############################");
            Category role = CategoryDAL.Query("duo7", msg);
             if(role==null)
                 System.Diagnostics.Debug.Write(msg);
             else
                 System.Diagnostics.Debug.Write(role.spec);
             System.Diagnostics.Debug.Write("###############################");
        }
    }
}