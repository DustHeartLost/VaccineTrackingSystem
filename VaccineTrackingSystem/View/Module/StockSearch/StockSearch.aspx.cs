﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using VaccineTrackingSystem.Models.BLL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.View.Module.StockSearch
{
    public partial class StockSearch : System.Web.UI.Page
    {
        protected static int storeID ;
        protected static int totalPage;
        protected static int currentPage;
        protected static int states;
        protected static string num=null;

        protected void Page_Load(object sender, EventArgs e)
        {
            totalPage = 0;
            currentPage = -1;
            states =0;
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
        [WebMethod]
        public static string Controller(int state, string data)
        {
            if (state != states)
            {
                totalPage = 0;
                currentPage = -1;
            }
            states = state;
            string temp = "";
            switch (state)
            {
                case 0: temp = precise(data); break;
           
            }
            return temp;
        }
        [WebMethod]
        public static string GetAll() {
            string msg;
            decimal money = 0;
            string data = StockManage.QueryAll(storeID,null, out msg,ref money,ref totalPage, ref currentPage);
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        public static string precise(string temp) {
            string msg;
            decimal money=0;
            num = temp;
            string data=StockManage.Query(storeID, temp,out msg,ref money, ref totalPage, ref currentPage);
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        
        [WebMethod]
        public static string GetDown()
        {
            if (num == null) return JsonConvert.SerializeObject(new Packet(201, "请输入药品编号"));
            string data = "";
            string msg="";
            decimal money = 0;
            switch (states)
            {
                case 0: data = StockManage.Query(storeID, num.ToString(), out msg, ref money, ref totalPage, ref currentPage); break;
            }
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
        [WebMethod]
        public static string GetUp()
        {
            if (num == null) return JsonConvert.SerializeObject(new Packet(201, "请输入药品编号"));
            if (currentPage == -1 || currentPage == 0) return JsonConvert.SerializeObject(new Packet(201, "没有记录"));
            currentPage -= 2;
            string data = "";
            string msg = "";
            decimal money = 0;
            switch (states)
            {
                case 0: data = StockManage.Query(storeID, num, out msg, ref money, ref totalPage, ref currentPage); break;
            }
            return data != null ? JsonConvert.SerializeObject(new Packet(200, data, $"{totalPage + 1}+{currentPage + 1}+{money}")) : JsonConvert.SerializeObject(new Packet(201, msg));
        }
    }
}