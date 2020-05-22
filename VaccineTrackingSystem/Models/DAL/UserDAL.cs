using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class UserDAL
    {
        static public bool Add(User user, out string msg)
        {
            string command = $"insert into [User] (userName,password,apartID,job,roleID,num,name) values ('{user.userName}','{user.password}','{user.apartID}','{user.job}','{user.roleID}','{user.num}','{user.name}');";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "员工编号或用户名重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }
        static public bool Update(User user, out string msg)
        {
            string command;
            if (user.password != null)
                command = $"update [User] set userName = '{user.userName}',password = '{user.password}',apartID =  '{user.apartID}',job = '{user.job}',roleID = '{user.roleID}',num = '{user.num}',name = '{user.name}' where id = '{user.id}'";
            else
                command = $"update [User] set userName = '{user.userName}',apartID =  '{user.apartID}',job = '{user.job}',roleID = '{user.roleID}',num = '{user.num}',name = '{user.name}' where id = '{user.id}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "员工编号或用户名重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }
        static public bool UpdateByName(string userName, string password, out string msg)
        {
            string command = $"update [User] set password = '{password}' where userName = '{userName}'";
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

        static public List<Dictionary<string, string>> Query(string name, out string msg)
        {
            string command;
            if (name == null)
                command = "select [User].id,[User].userName,Apartment.name as apartID,Apartment.num as apartNum,[User].job,Role.name as roleID,[User].num,[User].name from[User],Apartment,Role where[User].apartID=Apartment.id and [User].roleID=Role.id;";
            else
                command = $"select [User].id,[User].userName,Apartment.name as apartID,Apartment.num as apartNum,[User].job,Role.name as roleID,[User].num,[User].name from[User],Apartment,Role where[User].apartID=Apartment.id and [User].roleID=Role.id and [User].name like '{name}';";
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
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("userName", read["userName"].ToString());
                d.Add("apartID", (string)read["apartID"] + "(" + (string)read["apartNum"] + ")");
                d.Add("job", read["job"].ToString());
                d.Add("roleID", read["roleID"].ToString());
                d.Add("num", read["num"].ToString());
                d.Add("name", read["name"].ToString());
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
        //新加按照username查询的接口；2020-04-07,10:53
        static public Dictionary<string, string> QueryByUserName(string userName, string password, out string msg)
        {
            string command = $"with temp as(select userName,password,num,authority,[User].name from[User],Role where[User].roleID = Role.id) select userName,num,authority,name from temp where userName = '{userName}' and password = '{password}';";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("userName", (string)read["userName"]);
            dictionary.Add("num", (string)read["num"]);
            dictionary.Add("authority", (string)read["authority"]);
            dictionary.Add("name", (string)read["name"]);
            SQL.Dispose();
            msg = null;
            return dictionary;
        }

        static public Dictionary<string, string> GetUser()
        {
            string command = $"select num,[User].name from [User],Role where Role.id=[User].roleID and Role.name='库管员';";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                SQL.Dispose();
                return null;
            }
            Dictionary<string, string> list = new Dictionary<string, string>();
            while (read.Read())
            {
                list.Add((string)read["name"] + "(" + (string)read["num"] + ")", read["num"].ToString());

            }
            SQL.Dispose();
            return list;
        }



        static public List<Dictionary<string, string>> QueryUserStoreroom(string name, out string msg)
        {
            string command;
            if (name == null)   //查询所有
                command = "select [User].id,[User].userName,Apartment.name as apartID,Apartment.num as apartNum,[User].job,Role.name as roleID,[User].num,[User].name,'' as storeName,'无' as site from[User],Apartment,Role where[User].apartID=Apartment.id and [User].roleID=Role.id  and [User].storeID=-1 and  Role.name='库管员' union all select [User].id,[User].userName,Apartment.name as apartID,Apartment.num as apartNum,[User].job,Role.name as roleID,[User].num,[User].name,Storeroom.name as storeName,Storeroom.site from[User],Apartment,Role,Storeroom where[User].apartID=Apartment.id and [User].roleID=Role.id  and [User].storeID=Storeroom.id and Role.name='库管员';";
            //else if(name == 0)   //查询无库房
            //    command = "select [User].id,[User].userName,Apartment.name as apartID,Apartment.num as apartNum,[User].job,Role.name as roleID,[User].num,[User].name,'' as storeName,'无' as site from[User],Apartment,Role where[User].apartID=Apartment.id and [User].roleID=Role.id  and [User].storeID=-1 and Role.name='库管员';";
            else
                command = $"select [User].id,[User].userName,Apartment.name as apartID,Apartment.num as apartNum,[User].job,Role.name as roleID,[User].num,[User].name,'' as storeName,'无' as site from[User],Apartment,Role where[User].apartID=Apartment.id and [User].roleID=Role.id  and [User].storeID=-1 and  Role.name='库管员' and [User].name like '{name}' union all select [User].id,[User].userName,Apartment.name as apartID,Apartment.num as apartNum,[User].job,Role.name as roleID,[User].num,[User].name,Storeroom.name as storeName,Storeroom.site from[User],Apartment,Role,Storeroom where[User].apartID=Apartment.id and [User].roleID=Role.id  and [User].storeID=Storeroom.id and Role.name='库管员' and [User].name like '{name}';";
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
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("userName", read["userName"].ToString());
                d.Add("apartID", (string)read["apartID"] + "(" + (string)read["apartNum"] + ")");
                d.Add("job", read["job"].ToString());
                d.Add("roleID", read["roleID"].ToString());
                d.Add("num", read["num"].ToString());
                d.Add("name", read["name"].ToString());
                if (read["site"].ToString().Equals("无"))
                    d.Add("storeName", "无");
                else
                    d.Add("storeName", (string)read["storeName"] + "(" + (string)read["site"] + ")");
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

        static public bool UpdateUserStoreroom(int userId, int storeId, out string msg)
        {
            string command = $"update [User] set storeID = '{storeId}' where id = '{userId}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return false;
            }
        }


    }
}