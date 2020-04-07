using DAL;
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
        static public List<Inflow> QueryAllByStoreID(int storeID, out string msg)
        {
            string command = $"select * from Inflow where storeID = '{storeID}'";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
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

    }
}