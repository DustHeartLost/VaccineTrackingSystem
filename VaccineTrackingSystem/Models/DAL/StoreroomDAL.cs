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
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "请检查仓库名称是否重复或库管员是否已经绑定仓库";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }

        static public bool Update(Storeroom storeroom, out string msg)
        {
            
            string command = $"update Storeroom set name = '{storeroom.name}',site = '{storeroom.site}',userNum = '{storeroom.userNum}' where id = '{storeroom.id}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "仓库名称重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }
        static public List<Dictionary<string, string>> Query(string name, out string msg)
        {
            string command = $"select Storeroom.id,Storeroom.name,Storeroom.site,Storeroom.userNum,[User].name as username  from Storeroom,[User] where Storeroom.userNum=[User].num and Storeroom.name = '{name}'";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("id", read["id"].ToString());
                dictionary.Add("name", read["name"].ToString());
                dictionary.Add("site", read["site"].ToString());
                dictionary.Add("userNum", read["username"].ToString()+"("+ read["userNum"].ToString()+")");
                list.Add(dictionary);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
        static public List<Dictionary<string, string>> QueryAll(out string msg)
        {
            string command = $"select Storeroom.id,Storeroom.name,Storeroom.site,Storeroom.userNum,[User].name as username  from Storeroom,[User] where Storeroom.userNum=[User].num";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("id", read["id"].ToString());
                dictionary.Add("name", read["name"].ToString());
                dictionary.Add("site", read["site"].ToString());
                dictionary.Add("userNum", read["username"].ToString()+"("+ read["userNum"].ToString()+")");
                list.Add(dictionary);
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