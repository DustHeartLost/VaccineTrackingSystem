using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VaccineTrackingSystem.Models.BLL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.StockSearch
{
    public partial class StockSearch : System.Web.UI.Page
    {
        protected static int storeID;
        protected static int totalPage;
        protected static int currentPage;
        protected static int states;
        protected static string num = null;
        protected static JObject searchContext = new JObject();
        protected static List<string> drugs;
        protected static List<string> store;
        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            states = 0;
            if (HttpContext.Current.Session["user"] == null)
                Response.Write("<script language='javascript'>alert('登录信息过期，请重新登录');location.href='../../Login/Login.aspx'</script>");
            else
            {
                Dictionary<string, string> user = HttpContext.Current.Session["user"] as Dictionary<string, string>;
                try
                {
                    storeID = int.Parse(user["storeID"]);
                }
                catch
                {
                    storeID = -1;
                };
            }
            drugs = DrugManage.GetDrug().Keys.ToList();
            store = StoreManage.GetStoreroom().Keys.ToList();
        }

        [WebMethod]
        public static string GetAll()
        {
            string msg;
            decimal money = 0;
            states = 0;
            string data = StockManage.QueryAll(storeID, null, out msg, ref money, ref totalPage, ref currentPage, false);
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}+{storeID}", JsonConvert.SerializeObject(drugs), JsonConvert.SerializeObject(store))) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        public static string precise(string temp)
        {
            if (temp == null) return JsonConvert.SerializeObject(new Packet(201, "请输入药品编号"));
            string msg;
            decimal money = 0;
            string data = StockManage.Query(storeID, temp, out msg, ref money, ref totalPage, ref currentPage);
            if (data != null)
            {
                states = 1;
                num = temp;
                return JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}"));
            }
            return JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [WebMethod]
        public static string GetDown()
        {
            string data = "";
            string msg = "";
            decimal money = 0;
            switch (states)
            {
                case 0: data = GetAll(); return data;
                case 1: data = Models.BLL.StockManage.CombinationQuery(storeID, JsonConvert.SerializeObject(searchContext), out msg, ref totalPage, ref currentPage, out money); break;
            }
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }


        [WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string data = "";
            string msg = "";
            decimal money = 0;
            switch (states)
            {
                case 0: data = GetAll(); return data;
                case 1: data = Models.BLL.StockManage.CombinationQuery(storeID, JsonConvert.SerializeObject(searchContext), out msg, ref totalPage, ref currentPage, out money); break;
            }
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }


        [WebMethod]
        public static string ExportALL()
        {
            string data = "";
            string msg;
            decimal money = 0;
            switch (states)
            {
                case 0: data = StockManage.QueryAll(storeID, num, out msg, ref money, ref totalPage, ref currentPage, true); break;
                case 1: data = Models.BLL.StockManage.ExportConbinationInflow(storeID, JsonConvert.SerializeObject(searchContext), out msg, out money); ; break;
            }
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data)) : JsonConvert.SerializeObject(new Packet(201, "该搜索条件下没有需要导出的记录"));
        }

        [System.Web.Services.WebMethod]
        public static string SearchCon(string temp)
        {
            string msg;
            totalPage = 0;
            currentPage = -1;
            if (currentPage != -1)
            {
                currentPage--;
            }
            states = 1;
            decimal money = 0;
            JObject jo = (JObject)JsonConvert.DeserializeObject(temp);
            string cagNameTemp = jo["cagName"].ToString();
            if (cagNameTemp != null && cagNameTemp != "")
            {
                string t = "%";
                for (int i = 0; i < cagNameTemp.Length; i++)
                    t += cagNameTemp[i] + "%";
                jo["cagName"] = t;

            }
            else
                jo["cagName"] = "%";
            string storeNameTemp = jo["storeName"].ToString();
            if (storeNameTemp == null || storeNameTemp == "无")
                jo["storeName"] = "%";
            string cagNumTemp = jo["cagNum"].ToString();
            if (cagNumTemp != null && cagNumTemp != "")
            {
                string t = "%";
                for (int i = 0; i < cagNumTemp.Length; i++)
                    t += cagNumTemp[i] + "%";
                jo["cagNum"] = t;
            }
            else
                jo["cagNum"] = "%";

            string drugTemp = jo["drug"].ToString();
            if (drugTemp == "无(请选择品类名称)")
                jo["drug"] = "%";
            searchContext["cagName"] = jo["cagName"];
            searchContext["storeName"] = jo["storeName"];
            searchContext["cagNum"] = jo["cagNum"];
            searchContext["drug"] = jo["drug"];
            string jsonData = Models.BLL.StockManage.CombinationQuery(storeID, JsonConvert.SerializeObject(jo), out msg, ref totalPage, ref currentPage, out money);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}