using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.DAL
{
    public class RoleDAL
    {
        static public bool Add(Role role, string msg)
        {
            string command = $"insert into Role(name,authority,note) values('{role.name}','{role.authority}','{role.note}');";
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
            string command = $"delete from Role where id ={id}";
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
        static public bool Update(Role role, string msg)
        {
            string command = $"update Role set name = '{role.name}',authority = '{role.authority}',note =  '{role.note}' where id = '{role.id}'";
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
        static public Role Query(string name, string msg)
        {
            string command = $"select * from Role where name = '{name}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Role role = new Role((int)read["id"], (string)read["name"],(string)read["authority"],(string)read["note"]);
            SQL.Dispose();
            return role;
        }
        static public List<Role> QueryAll(string msg)
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
                list.Add(new Role((int)read["id"], (string)read["name"], (string)read["authority"], (string)read["note"]));
            }
            SQL.Dispose();
            return list;
        }

    }
}