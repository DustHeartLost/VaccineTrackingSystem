using System;
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
            /*测试outflow查询代码*/
            //string msg = "";
            //Outflow list = OutflowDAL.Query(2,msg);
            //if (list == null)
            //{
            //    Label1.Text = msg;
            //}
            //else {
            //    Label1.Text = list.date;
            //}
            /*测试outflow插入代码*/
            //string msg = "";
            //Outflow outflow = new Outflow(1,"23",2,"2020-04-15","456",20,12.8m,"2020-04-25","正常出库");
            //if (OutflowDAL.Add(outflow, msg)) { msg = "插入成功"; };
            //Label1.Text = msg;

            /*测试indetail代码*/

            /*List<Indetail> indetail = IndetailDAL.QueryAll (msg);
            //if (indetail == null)
            //{
            //    Label1.Text = "没有查询到结果";
            //}
            //else {
            //    foreach (Indetail x in indetail) {
            //        Label1.Text = x.price.ToString();
            //    }
            //};*/
            Indetail indetail = new Indetail(2, "123", "2020-04-05", 21, 13.05m, null);
            string msg = " ";
            if (IndetailDAL.Delete(6, out msg))
            {
                Label1.Text = "删除成功";
            }
            else
            {
                Label1.Text = msg;
            }
        }
    }
}