﻿using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class InflowDAL
    {
        static public bool Add(Inflow inflow, out string msg)
        {
            string command = $"insert into Inflow (cagNum,storeID,date,userNum,quantity,price,batchNum) values ('{inflow.cagNum}','{inflow.storeID}','{inflow.date}','{inflow.userNum}','{inflow.quantity}','{inflow.price}','{inflow.batchNum}')";
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

        static public Inflow Query(int id, out string msg)
        {
            string command = $"select * from Inflow where id = '{id}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Inflow inflow = new Inflow((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (string)read["date"], (string)read["userNum"], (int)read["quantity"], (decimal)read["price"], (string)read["batchNum"]);
            SQL.Dispose();
            msg = null;
            return inflow;
        }
        static public List<Inflow> QueryAll(out string msg)
        {
            string command = "select * from Inflow";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            List<Inflow> list = new List<Inflow>();
            Inflow inflow;
            while (read.Read())
            {
                inflow = new Inflow((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (string)read["date"], (string)read["userNum"], (int)read["quantity"], (decimal)read["price"], (string)read["batchNum"]);
                list.Add(inflow);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
        //新增按照仓库ID查找入库流水表2020-04-07 18：07
        static public List<Dictionary<string,string>> QueryAllByStoreID(int storeID, out string msg)
        {
            string command;
            if(storeID!=-1)
                command = $"select inflow.id,Inflow.cagNum,Storeroom.name as storeID,Inflow.date,[User].name as userName,[User].num,Inflow.quantity,inflow.price,Inflow.batchNum from Inflow,[User], Storeroom where inflow.storeID = Storeroom.id and Inflow.userNum =[User].num and Storeroom.id = '{storeID}'";
            else
                command = $" select inflow.id,Inflow.cagNum,Storeroom.name as storeID,Inflow.date,[User].name as userName,[User].num,Inflow.quantity,inflow.price,Inflow.batchNum from Inflow,[User], Storeroom where inflow.storeID = Storeroom.id and Inflow.userNum =[User].num;";
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
                d.Add("id",read["id"].ToString());
                d.Add("cagNum", (string)read["cagNum"]);
                d.Add("storeID", (string)read["storeID"]);
                d.Add("date", (string)read["date"]);
                d.Add("userNum", (string)read["userName"]+"("+ (string)read["num"] + ")");
                d.Add("quantity", read["quantity"].ToString());
                d.Add("price", read["price"].ToString());
                d.Add("batchNum", (string)read["batchNum"]);
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

    }
}