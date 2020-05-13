using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using VaccineTrackingSystem.Models.BLL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Inflow
{
    public partial class InflowAdd : System.Web.UI.Page
    {
        private static int storeId;
        private static string userNum;
        protected static Dictionary<string, string> category;
        protected static List<string> suppliers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
            else
            {
                Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
                try
                {
                    storeId = int.Parse(user["storeID"]);
                }
                catch
                {
                    Response.Write("<script language='javascript'>alert('您没有绑定的仓库');location.href='../../Home/Home.aspx'</script>");
                };
                userNum = user["num"];
                category = CategoryManage.GetCate();
                suppliers = SupplierManage.GetSuppliers();
            }
        }

        [System.Web.Services.WebMethod]
        public static string Insert(string temp)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string msg;
            Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd");
            int quantity = int.Parse(jo["quantity"].ToString());
            decimal price = decimal.Parse(jo["price"].ToString());
            string cagNum = jo["cagNum"].ToString();
            string batchNum = jo["batchNum"].ToString();
            string suppliers=jo["suppliers"].ToString();
            if (!category.ContainsKey(cagNum)) return JsonConvert.SerializeObject(new Packet(203, "输入的药品品类不存在"));
            cagNum = category[jo["cagNum"].ToString()];
            if (!suppliers.Contains(suppliers)) return JsonConvert.SerializeObject(new Packet(203, "输入的供应商不存在"));
            try
            {
                DateTime dt = DateTime.ParseExact(batchNum, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                Models.Inflow inflow = new Models.Inflow(cagNum, storeId, nowTime, userNum, quantity, price, batchNum);
                return Models.BLL.InflowManage.InWarehouse(inflow, out msg) ? JsonConvert.SerializeObject(new Packet(200, "入库成功")) : JsonConvert.SerializeObject(new Packet(203, msg));
            }
            catch
            {
                return JsonConvert.SerializeObject(new Packet(203, "到期时间格式错误，例：20200101"));
            }

        }
        [System.Web.Services.WebMethod]
        public static string GetData()
        {
            int code=200;
            if( (category == null || category.Count == 0) &&(suppliers==null || suppliers.Count==0))return JsonConvert.SerializeObject(new Packet(201, "暂无药品品类和供应商,请增加后相关数据后刷新重试"));
            if ((category == null || category.Count == 0) && (suppliers != null || suppliers.Count != 0)) code = 205;
            if ((category != null || category.Count != 0) && (suppliers == null || suppliers.Count == 0)) code = 206;
            return JsonConvert.SerializeObject(new Packet(code, JsonConvert.SerializeObject(category.Keys), JsonConvert.SerializeObject(suppliers)));
        }
    }
}