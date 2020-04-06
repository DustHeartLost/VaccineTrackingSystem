using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.DAL
{
    public class StoreroomDAL
    {
        static public bool Add(Storeroom storeroom,string msg)
        {
            string command = $"insert into Storeroom(name,site,userNum) values('{storeroom.name}','{storeroom.site}','{storeroom.userNum}');";
            try
            {
                return SQL.Excute(command);
            }
            catch (Exception e)
            {
                msg = e.Message;
                System.Diagnostics.Debug.Write(msg);
                return false;
            }
        }
        static public bool Delete(int id, string msg)
        {
            string command = $"delete from Storeroom where id ={id}";
            try
            {
                return SQL.Excute(command);
            }
            catch (Exception e)
            {
                msg = e.Message;
                System.Diagnostics.Debug.Write(msg);
                return false;
            }
        }
        static public bool Update(Storeroom storeroom,string msg)
        {
            string command = $"update Storeroom set name = '{storeroom.name}',site = '{storeroom.site}',userNum =  '{storeroom.userNum}' where id = '{storeroom.id}'";
            try
            {
                return SQL.Excute(command);
            }
            catch (Exception e)
            {
                msg = e.Message;
                System.Diagnostics.Debug.Write(msg);
                return false;
            }
        }
        static public Storeroom Query(int id, string msg)
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
            return storeroom;
        }
        static public List<Storeroom> QueryAll(string msg)
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
            return list;
        }

    }
}