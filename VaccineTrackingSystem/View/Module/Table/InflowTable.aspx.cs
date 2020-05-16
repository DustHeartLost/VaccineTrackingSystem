using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Table
{
    public partial class InflowTable : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;
        protected static int states;
        protected static int storeID;
        protected static JObject searchContext=new JObject();
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
        }

        [System.Web.Services.WebMethod]
        public static string GetALLInflow()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            decimal money = 0;
            states = 0;
            string msg;
            //TODO:此处的ID将来换成从session中取
            string jsonData = Models.BLL.TableManage.queryAllInflow(storeID, ref totalPage, ref currentPage, out msg, out money);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
      
        [System.Web.Services.WebMethod]
        public static string GetDown()
        {
            string temp = "";
            string msg = "";
            decimal money = 0;
            //System.Diagnostics.Debug.Write("#####"+searchContext["date"].ToString() + searchContext["cagName"].ToString() + searchContext["storeName"].ToString() + searchContext["cagNum"].ToString());
            switch (states)
            {
                case 0: temp = Models.BLL.TableManage.queryAllInflow(storeID, ref totalPage, ref currentPage, out msg, out money); break;
                case 1: temp = Models.BLL.TableManage.InflowCombinationQuery(storeID, JsonConvert.SerializeObject(searchContext), out msg, ref totalPage, ref currentPage, out money); break;
            }
            return temp != null ? JsonConvert.SerializeObject(new Packet(200, temp, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string temp = "";
            string msg = "";
            decimal money = 0;
            switch (states)
            {
                case 0: temp = Models.BLL.TableManage.queryAllInflow(storeID, ref totalPage, ref currentPage, out msg, out money); break;
                case 1: temp = Models.BLL.TableManage.InflowCombinationQuery(storeID, JsonConvert.SerializeObject(searchContext), out msg, ref totalPage, ref currentPage, out money); break;
            }
            return temp != null ? JsonConvert.SerializeObject(new Packet(200, temp, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));

        }

        [System.Web.Services.WebMethod]
        public static string ExportALL()
        {
            decimal money = 0;
            string msg = "";
            string temp = "";
            switch (states)
            {
                case 0: temp = Models.BLL.TableManage.ExportInflow(storeID, out msg, out money); break;
                case 1: temp = Models.BLL.TableManage.ExportConbinationInflow(storeID, JsonConvert.SerializeObject(searchContext), out msg, out money); ; break;
            }
            return temp != null ? JsonConvert.SerializeObject(new Packet(200, temp, $"{states}")) : JsonConvert.SerializeObject(new Packet(201, "该搜索条件下没有需要导出的记录"));
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
            string dateTemp = jo["date"].ToString();
            if (dateTemp != null && dateTemp != "")
            {
                string t = "%";
                for (int i = 0; i < dateTemp.Length; i++)
                    t += dateTemp[i] + "%";

                jo["date"] = t;
            }
            else
                jo["date"] = "%";
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
            if (storeNameTemp != null && storeNameTemp != "")
            {
                string t = "%";
                for (int i = 0; i < storeNameTemp.Length; i++)
                    t += storeNameTemp[i] + "%";
                jo["storeName"] = t;

            }
            else
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
            searchContext["date"] = jo["date"];
            searchContext["cagName"] = jo["cagName"];
            searchContext["storeName"] = jo["storeName"];
            searchContext["cagNum"] = jo["cagNum"];
            string jsonData = Models.BLL.TableManage.InflowCombinationQuery(storeID, JsonConvert.SerializeObject(jo), out msg, ref totalPage, ref currentPage, out money);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

    }
}