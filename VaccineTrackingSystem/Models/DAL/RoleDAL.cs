using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class RoleDAL
    {
        static public bool Add(Role role, out string msg)
        {
            string command = $"insert into Role(name,authority,note) values('{role.name}','{role.authority}','{role.note}');";
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

        static public bool Update(Role role, out string msg)
        {
            string command = $"update Role set name = '{role.name}',authority = '{role.authority}',note =  '{role.note}' where id = '{role.id}'";
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
        static public Role Query(string name, out string msg)
        {
            string command = $"select * from Role where name = '{name}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Role role = new Role((int)read["id"], (string)read["name"], (string)read["authority"], (string)read["note"]);
            SQL.Dispose();
            msg = null;
            return role;
        }
        static public List<Role> QueryAll(out string msg)
        {
            string command = "select * from Role";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<Role> list = new List<Role>();
            while (read.Read())
            {
                //此处为处理note为空的异常，不可以强制转换，只可以使用ToString方法
                list.Add(new Role((int)read["id"], (string)read["name"], (string)read["authority"], read["note"].ToString()));
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
        static public Dictionary<string,int> GetRole()
        {
            string command = $"select id,name from role;";
            SqlDataReader read = SQL.getReader(command);
            if (read == null) return null;
            Dictionary<string, int> role = new Dictionary<string, int>();
            while (read.Read())
            {
                role.Add((string)read["name"] ,(int)read["id"]);
            }
            SQL.Dispose();
            return role;
        }
    }
}