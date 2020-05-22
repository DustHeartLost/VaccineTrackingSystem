using DAL;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class StoreroomDAL
    {
        static public bool Add(Storeroom storeroom, out string msg)
        {
            string command = $"insert into Storeroom(name,site) values('{storeroom.name}','{storeroom.site}');";
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

            string command = $"update Storeroom set name = '{storeroom.name}',site = '{storeroom.site}' where id = '{storeroom.id}'";
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
        static public List<Dictionary<string, string>> Query(string name, out string msg)
        {
            string command = $"select Storeroom.id,Storeroom.name,Storeroom.site  from Storeroom where Storeroom.name = '{name}'";
            SqlDataReader read = SQL.getReader(command);
            if (!read.HasRows)
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
                list.Add(dictionary);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
        static public List<Dictionary<string, string>> QueryAll(out string msg)
        {
            string command = $"select Storeroom.id,Storeroom.name,Storeroom.site  from Storeroom";
            SqlDataReader read = SQL.getReader(command);
            if (!read.HasRows)
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
                list.Add(dictionary);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }


        //新加的按照用户编号查询的接口2020-04-07
        static public Storeroom QueryByUserNum(string userNum)
        {
            string command = $"select storeID from [User] where num = '{userNum}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                SQL.Dispose();
                return null;
            }
            if ((int)read["storeID"] == -1)
            {
                SQL.Dispose();
                return null;
            }
            Storeroom storeroom = new Storeroom((int)read["storeID"], null, null, null);
            SQL.Dispose();
            return storeroom;
        }

        //新增查找id-name(site) 5-21
        public static Dictionary<string, int> GetStoreroom()
        {
            string command = $"select id,name,site from Storeroom";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                SQL.Dispose();
                return null;
            }
            Dictionary<string, int> storeroom = new Dictionary<string, int>();
            storeroom.Add("无", -1);
            while (read.Read())
            {
                storeroom.Add((string)read["name"] + "(" + (string)read["site"] + ")", (int)read["id"]);
            }
            SQL.Dispose();
            return storeroom;
        }
    }
}