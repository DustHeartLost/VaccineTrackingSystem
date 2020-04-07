using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class OutflowDAL
    {
        static public bool Add(Outflow outflow, out string msg)
        {
            string command = $"insert into Outflow (cagNum,storeID,date,userNum,quantity,price,batchNum,state) values ('{outflow.cagNum}','{outflow.storeID}','{outflow.date}','{outflow.userNum}','{outflow.quantity}','{outflow.price}','{outflow.batchNum}','{outflow.state}')";
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

        static public Outflow Query(int id, out string msg)
        {
            string command = $"select * from Outflow where id = '{id}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                return null;
            }
            Outflow outflow = new Outflow((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (string)read["date"], (string)read["userNum"], (int)read["quantity"], (decimal)read["price"], (string)read["batchNum"], (string)read["state"]);
            SQL.Dispose();
            msg = null;
            return outflow;
        }
        //根据药品编码精确
        //static public List<Outflow> Query(string cagNum, out string msg)
        //{

        //}
        static public List<Outflow> QueryAll(out string msg)
        {
            string command = "select * from Outflow";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                return null;
            }
            List<Outflow> list = new List<Outflow>();
            Outflow outflow;
            while (read.Read())
            {
                outflow = new Outflow((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (string)read["date"], (string)read["userNum"], (int)read["quantity"], (decimal)read["price"], (string)read["batchNum"], (string)read["state"]);
                list.Add(outflow);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
    }
}