using DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class OutflowDAL
    {
        static public bool Add(Outflow outflow, out string msg)
        {
            string command = $"insert into Outflow (cagNum,storeID,date,userNum,quantity,price,batchNum,batchNum2,suppliers,state) values ('{outflow.cagNum}','{outflow.storeID}','{outflow.date}','{outflow.userNum}','{outflow.quantity}','{outflow.price}','{outflow.batchNum}','{outflow.batchNum2}','{outflow.suppliers}','{outflow.state}')";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

        //新增按照仓库ID查找出库流水表2020-04-07 18：07
        static public List<Dictionary<string, string>> QueryAllByStoreID(int storeID, out string msg)
        {
            string command;
            if (storeID != -1)
                command = $"select Outflow.id,Outflow.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Outflow.date,[User].name as userName,[User].num,Outflow.quantity,Outflow.price,Outflow.batchNum,Outflow.batchNum2,Outflow.suppliers,Outflow.state from Outflow,[User], Storeroom,Category where Outflow.storeID = Storeroom.id and Outflow.userNum =[User].num and  Outflow.cagNum=Category.num and Storeroom.id = '{storeID}'";
            else
                command = $"select Outflow.id,Outflow.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Outflow.date,[User].name as userName,[User].num,Outflow.quantity,Outflow.price,Outflow.batchNum,Outflow.batchNum2,Outflow.suppliers,Outflow.state from Outflow,[User], Storeroom,Category where Outflow.storeID = Storeroom.id and Outflow.userNum =[User].num and  Outflow.cagNum=Category.num;";

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
                d.Add("state", read["state"].ToString());
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
                command = $"select Outflow.id,Outflow.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Outflow.date,[User].name as userName,[User].num,Outflow.quantity,Outflow.price,Outflow.batchNum,Outflow.batchNum2,Outflow.suppliers,Outflow.state from Outflow,[User], Storeroom,Category where Outflow.storeID = Storeroom.id and Outflow.userNum =[User].num and  Outflow.cagNum=Category.num and Storeroom.id = '{storeID}'and Outflow.date like '{keyWords["date"]}' and Category.num like '{keyWords["cagNum"]}' and Category.name like '{keyWords["cagName"]}'  and Storeroom.name like '{keyWords["storeName"]}' and Outflow.state like '{keyWords["state"]}'";
            else
                command = $"select Outflow.id,Outflow.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Outflow.date,[User].name as userName,[User].num,Outflow.quantity,Outflow.price,Outflow.batchNum,Outflow.batchNum2,Outflow.suppliers,Outflow.state from Outflow,[User], Storeroom,Category where Outflow.storeID = Storeroom.id and Outflow.userNum =[User].num and  Outflow.cagNum=Category.num and Outflow.date like '{keyWords["date"]}' and Category.num like '{keyWords["cagNum"]}' and Category.name like '{keyWords["cagName"]}'  and Storeroom.name like '{keyWords["storeName"]}' and Outflow.state like '{keyWords["state"]}'";
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
                d.Add("state", read["state"].ToString());
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
    }
}