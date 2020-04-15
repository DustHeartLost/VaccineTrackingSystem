using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.Table
{
    public partial class Table : System.Web.UI.Page
    {
        protected static int totalPage;
        protected static int currentPage;
        protected static int states;
        protected static int storeID;
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
        public static string Controller(int state,string data) {
            if (state != states)
            {
                totalPage = 0;
                currentPage = -1;
            }  
            states = state;
            string temp="";
            switch (state) {
                case 0: temp=GetALLInflow();break;
                case 1: temp=GetALLOutflow(); break;
            }
            return temp;
        }


        [System.Web.Services.WebMethod]
        public static string GetALLInflow()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            decimal money=0;
            string msg;
            //TODO:此处的ID将来换成从session中取
            string jsonData = Models.BLL.TableManage.queryAllInflow(storeID, ref totalPage, ref currentPage, out msg,out money);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetALLOutflow()
        {
            if (currentPage != -1)
            {
                currentPage--;
            }
            decimal money = 0;
            string msg;
            //TODO:此处的ID将来换成从session中取
            string jsonData = Models.BLL.TableManage.queryAllOutflow(storeID, ref totalPage, ref currentPage, out msg, out money);
            return jsonData != null ? JsonConvert.SerializeObject(new Packet(200, jsonData, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }

        [System.Web.Services.WebMethod]
        public static string GetDown()
        {
            string temp = "";
            string msg="";
            decimal money = 0;
            switch (states)
            {
                case 0: temp=Models.BLL.TableManage.queryAllInflow(storeID, ref totalPage, ref currentPage, out msg, out money); break;
                case 1: temp = Models.BLL.TableManage.queryAllOutflow(3, ref totalPage, ref currentPage, out msg, out money); break;
            }
            return temp!= null ? JsonConvert.SerializeObject(new Packet(200, temp, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [System.Web.Services.WebMethod]
        public static string GetUp()
        {
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string temp = "";
            string msg="";
            decimal money=0;
            switch (states)
            {
                case 0: temp = Models.BLL.TableManage.queryAllInflow(storeID, ref totalPage, ref currentPage, out msg, out money); break;
                case 1: temp = Models.BLL.TableManage.queryAllOutflow(3, ref totalPage, ref currentPage, out msg, out money); break;
            }
            return temp != null ? JsonConvert.SerializeObject(new Packet(200, temp, $"{totalPage + 1}+{currentPage + 1}+{money}+{states}")) : JsonConvert.SerializeObject(new Packet(201, msg));

        }
    }
}