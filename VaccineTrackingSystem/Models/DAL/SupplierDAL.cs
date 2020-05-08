﻿using DAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.Models.DAL
{
    public class SupplierDAL
    {
        static public bool Add(Suppliers suppliers, out string msg)
        {
            string command = $"insert into Suppliers(name,code) values('{suppliers.name}','{suppliers.code}');";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "供应商代码重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }

        static public bool Update(Suppliers suppliers, out string msg)
        {
            string command = $"update Suppliers set name = '{suppliers.name}',code =  '{suppliers.code}' where id = '{suppliers.id}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "供应商代码重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }
        static public Suppliers Query(string name, out string msg)
        {
            string command = $"select * from Suppliers where name = '{name}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Suppliers suppliers= new Suppliers((int)read["id"], (string)read["name"], (string)read["code"]);
            SQL.Dispose();
            msg = null;
            return suppliers;
        }
        static public List<Suppliers> QueryAll(out string msg)
        {
            string command = "select * from Suppliers";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<Suppliers> list = new List<Suppliers>();
            while (read.Read())
            {
                //此处为处理note为空的异常，不可以强制转换，只可以使用ToString方法
                list.Add(new Suppliers((int)read["id"], (string)read["name"], (string)read["code"]));
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
        static public Dictionary<string, string> GetSuppliers()
        {
            string command = $"select name,code from Suppliers order by name;";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                SQL.Dispose();
                return null;
            }
            Dictionary<string, string> suppliers = new Dictionary<string, string>();
            while (read.Read())
            {
                suppliers.Add((string)read["name"], (string)read["code"]);
            }
            SQL.Dispose();
            return suppliers;
        }
    }
}