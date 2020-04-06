using System;
using System.Collections.Generic;
using VaccineTrackingSystem.Models;
using VaccineTrackingSystem.Models.BLL;
using VaccineTrackingSystem.Models.DAL;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg=null;
            System.Diagnostics.Debug.Write("###############################");
            System.Diagnostics.Debug.Write(AprtManage.Query("wy", msg).note);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*测试outflow查询代码*/
            string msg;
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
            //Indetail indetail = new Indetail(2, "123", "2020-04-05", 21, 13.05m, null);

            //if (IndetailDAL.Delete(6, out msg))
            //{
            //    Label1.Text = "删除成功";
            //}
            //else
            //{
            //    Label1.Text = msg;
            //}
            //Inflow inflow = InflowDAL.Query(1,out msg);
            //if (inflow == null)
            //{
            //    Label1.Text = "没有查询到结果";
            //}
            //else
            //{
            //    Label1.Text = inflow.date;
            //};
            //Inflow outflow = new Inflow(1, "123", 3, "2020-04-15", "123", 20, 12.8m, "2020-04-25");
            //if (InflowDAL.Add(outflow,out msg)) { msg = "插入成功"; };
            //Label1.Text = msg;
            //List<Stock> stock = StockDAL.QueryAll ( out msg);
            //if (stock == null)
            //{
            //    Label1.Text = "没有查询到结果";
            //}
            //else
            //{
            //    foreach (Stock x in stock)
            //    {
            //        Label1.Text = x.money.ToString();

            //    };
            //}
            Stock stock = new Stock("123", 3, 20, 12.8m);
            if (StockDAL.Add(stock, out msg)) { msg = "插入成功"; };
            Label1.Text = msg;
        }
    }
}