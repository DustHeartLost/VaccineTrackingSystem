﻿using DAL;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class InflowDAL
    {
        static public bool Add(Inflow inflow, out string msg)
        {
            string command = $"insert into Inflow (cagNum,storeID,date,userNum,quantity,price,batchNum,batchNum2,suppliers) values ('{inflow.cagNum}','{inflow.storeID}','{inflow.date}','{inflow.userNum}','{inflow.quantity}','{inflow.price}','{inflow.batchNum}','{inflow.batchNum2}','{inflow.suppliers}')";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    msg = "添加失败，批号重复";
                    return false;
                }
                msg = ex.Message;
                return false;
            }
        }

        //新增按照仓库ID查找入库流水表2020-04-07 18：07
        static public List<Dictionary<string, string>> QueryAllByStoreID(int storeID, out string msg)
        {
            string command;
            if (storeID != -1)
                command = $"select Inflow.id,Inflow.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Inflow.date,[User].name as userName,[User].num,Inflow.quantity,inflow.price,Inflow.batchNum,inflow.batchNum2,Inflow.suppliers from Inflow,[User], Storeroom,Category where inflow.storeID = Storeroom.id and Inflow.userNum =[User].num and  Inflow.cagNum=Category.num and Storeroom.id = '{storeID}'";
            else
                command = $" select Inflow.id,Inflow.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Inflow.date,[User].name as userName,[User].num,Inflow.quantity,inflow.price,Inflow.batchNum,inflow.batchNum2,Inflow.suppliers from Inflow,[User], Storeroom,Category where inflow.storeID = Storeroom.id and Inflow.userNum =[User].num and  Inflow.cagNum=Category.num ;";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("cagNum", (string)read["cagNum"]);
                d.Add("name", (string)read["name"]);
                d.Add("kind", (string)read["kind"]);
                d.Add("spec", (string)read["spec"]);
                d.Add("storeID", (string)read["storeID"]);
                d.Add("date", (string)read["date"]);
                d.Add("userNum", (string)read["userName"] + "(" + (string)read["num"] + ")");
                d.Add("quantity", read["quantity"].ToString());
                d.Add("price", read["price"].ToString());
                d.Add("batchNum", (string)read["batchNum"]);
                d.Add("batchNum2", read["batchNum2"].ToString());
                d.Add("suppliers", (string)read["suppliers"]);
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

        //当天所有入库记录
        static public List<Dictionary<string, string>> QueryTodayRecoder(int storeID, string nowTime, out string msg)
        {
            string command = $"select Inflow.id,Inflow.cagNum,Category.name as cagName,Category.kind,Category.spec,Inflow.date,Inflow.quantity,Inflow.price,Inflow.batchNum from Inflow , Category where Inflow.cagNum = Category.num and Inflow.storeID =  '{storeID}' and Inflow.date='{nowTime}'";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "暂无入库记录";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("cagNum", (string)read["cagNum"]);
                d.Add("cagName", (string)read["cagName"]);
                d.Add("kind", (string)read["kind"]);
                d.Add("spec", (string)read["spec"]);
                d.Add("date", (string)read["date"]);
                d.Add("quantity", read["quantity"].ToString());
                d.Add("price", read["price"].ToString());
                d.Add("batchNum", (string)read["batchNum"]);
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }


        //组合查找
        static public List<Dictionary<string, string>> CombinationQuery(JObject keyWords, int storeID, out string msg)
        {
            string command;
            if (storeID != -1)
                command = $"select Inflow.id,Inflow.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Inflow.date,[User].name as userName,[User].num,Inflow.quantity,inflow.price,Inflow.batchNum,inflow.batchNum2,Inflow.suppliers from Inflow,[User], Storeroom,Category where inflow.storeID = Storeroom.id and Inflow.userNum =[User].num and  Inflow.cagNum=Category.num and Storeroom.id = '{storeID}'and Inflow.date like '{keyWords["date"]}' and Category.num like '{keyWords["cagNum"]}' and Category.name like '{keyWords["cagName"]}'  and Storeroom.name like '{keyWords["storeName"].ToString()}'";
            else
                command = $" select Inflow.id,Inflow.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Inflow.date,[User].name as userName,[User].num,Inflow.quantity,inflow.price,Inflow.batchNum,inflow.batchNum2,Inflow.suppliers from Inflow,[User], Storeroom,Category where inflow.storeID = Storeroom.id and Inflow.userNum =[User].num and  Inflow.cagNum=Category.num and Inflow.date like '{keyWords["date"]}' and Category.num like '{keyWords["cagNum"]}' and Category.name like '{keyWords["cagName"]}' and Storeroom.name like '{keyWords["storeName"]}';";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("cagNum", (string)read["cagNum"]);
                d.Add("name", (string)read["name"]);
                d.Add("kind", (string)read["kind"]);
                d.Add("spec", (string)read["spec"]);
                d.Add("storeID", (string)read["storeID"]);
                d.Add("date", (string)read["date"]);
                d.Add("userNum", (string)read["userName"] + "(" + (string)read["num"] + ")");
                d.Add("quantity", read["quantity"].ToString());
                d.Add("price", read["price"].ToString());
                d.Add("batchNum", (string)read["batchNum"]);
                d.Add("batchNum2", read["batchNum2"].ToString());
                d.Add("suppliers", (string)read["suppliers"]);
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
    }
}