using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class CategoryDAL
    {
        static public bool Add(Category category, out string msg)
        {
            string command = $"insert into Category(num,name,kind,unit,spec,factory,note) values('{category.num}','{category.name}','{category.kind}','{category.unit}','{category.spec}','{category.factory}','{category.note}');";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "药品编号重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }
        
        static public bool Update(Category category, out string msg)
        {
            string command = $"update Category set num = '{category.num}',name = '{category.name}',kind = '{category.kind}',unit = '{category.unit}',spec = '{category.spec}',factory = '{category.factory}',note = '{category.note}' where id = '{category.id}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "药品编号重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }
        static public Category Query(string num, out string msg)
        {
            string command = $"select * from Category where num = '{num}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Category category = new Category((int)read["id"], (string)read["num"], (string)read["name"], (string)read["kind"], (string)read["unit"], (string)read["spec"], (string)read["factory"], read["note"].ToString());
            SQL.Dispose();
            msg = null;
            return category;
        }
        static public List<Category> QueryAll(out string msg)
        {
            string command = "select * from Category";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<Category> list = new List<Category>();
            while (read.Read())
            {
                list.Add(new Category((int)read["id"], (string)read["num"], (string)read["name"], (string)read["kind"], (string)read["unit"], (string)read["spec"], (string)read["factory"], read["note"].ToString()));
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

        static public Dictionary<string, string> GetCate()
        {
            string command = $"select num,name from  Category;";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                SQL.Dispose();
                return null;
            }
            Dictionary<string, string>  category = new Dictionary<string, string>();
            while (read.Read())
            {
                category.Add((string)read["name"] + "(" + (string)read["num"] + ")", read["num"].ToString());

            }
            SQL.Dispose();
            return category;
        }

    }
}