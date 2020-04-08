using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class StoreroomDAL
    {
        static public bool Add(Storeroom storeroom, out string msg)
        {
            string command = $"insert into Storeroom(name,site,userNum) values('{storeroom.name}','{storeroom.site}','{storeroom.userNum}');";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (Exception e)
            {
                msg = e.Message;
                System.Diagnostics.Debug.Write(msg);
                return false;
            }
        }
        static public bool Delete(int id, out string msg)
        {
            string command = $"delete from Storeroom where id ={id}";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (Exception e)
            {
                msg = e.Message;
                System.Diagnostics.Debug.Write(msg);
                return false;
            }
        }
        static public bool Update(Storeroom storeroom, out string msg)
        {
            string command = $"update Storeroom set name = '{storeroom.name}',site = '{storeroom.site}',userNum =  '{storeroom.userNum}' where id = '{storeroom.id}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (Exception e)
            {
                msg = e.Message;
                System.Diagnostics.Debug.Write(msg);
                return false;
            }
        }
        static public Storeroom Query(int id, out string msg)
        {
            string command = $"select * from Storeroom where id = '{id}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Storeroom storeroom = new Storeroom((int)read["id"], (string)read["name"], (string)read["site"], (string)read["userNum"]);
            SQL.Dispose();
            msg = null;
            return storeroom;
        }
        static public List<Storeroom> QueryAll(out string msg)
        {
            string command = $"select * from Storeroom";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<Storeroom> list = new List<Storeroom>();
            while (read.Read())
            {
                list.Add(new Storeroom((int)read["id"], (string)read["name"], (string)read["site"], (string)read["userNum"]));
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
        //新加的按照用户编号查询的接口2020-04-07
        static public Storeroom QueryByUserNum(string userNum)
        {
            string command = $"select id from Storeroom where userNum = '{userNum}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                SQL.Dispose();
                return null;
            }
            Storeroom storeroom = new Storeroom((int)read["id"], null, null, null);
            SQL.Dispose();
            return storeroom;
        }
    }
}