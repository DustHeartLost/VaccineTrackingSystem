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
            catch (Exception e)
            {
                msg = e.Message;
                System.Diagnostics.Debug.Write(msg);
                return false;
            }
        }
        static public bool Delete(int id, out string msg)
        {
            string command = $"delete from [User] where id ={id}";
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
        static public bool Update(User user, out string msg)
        {
            string command = $"update [User] set userName = '{user.userName}',password = '{user.password}',apartID =  '{user.apartID}',job = '{user.job}',roleID = '{user.roleID}',num = '{user.num}',name = '{user.name}' where id = '{user.id}'";
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
        static public User Query(string num, out string msg)
        {
            string command = $"select * from [User] where num = '{num}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            User user = new User((int)read["id"], (string)read["userName"], (string)read["password"], (int)read["apartID"], (string)read["job"], (int)read["roleID"], (string)read["num"], (string)read["name"]);
            SQL.Dispose();
            msg = null;
            return user;
        }
        static public List<User> QueryAll(out string msg)
        {
            string command = "select * from [User]";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<User> list = new List<User>();
            while (read.Read())
            {
                list.Add(new User((int)read["id"], (string)read["userName"], (string)read["password"], (int)read["apartID"], (string)read["job"], (int)read["roleID"], (string)read["num"], (string)read["name"]));
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
        //新加按照username查询的接口；2020-04-07,10:53
        static public Dictionary<string, string> QueryByUserName(string userName, string password, out string msg)
        {
            string command = $"with temp as(select userName,password,num,authority from[User],Role where[User].roleID = Role.id) select userName,num,authority from temp where userName = '{userName}' and password = '{password}';";
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
            SQL.Dispose();
            msg = null;
            return dictionary;
        }
    }
}