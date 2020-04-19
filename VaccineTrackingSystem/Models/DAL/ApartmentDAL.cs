using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class ApartmentDAL
    {

        static public bool Add(Apartment apartment, out string msg)
        {
            string command = $"insert into Apartment(num,name,note) values('{apartment.num}','{apartment.name}','{apartment.note}');";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "部门编号重复";
                }
                else { 
                    msg = e.Message;
                }   
                return false;
            }
        }
        
        static public bool Update(Apartment apartment, out string msg)
        {
            string command = $"update Apartment set num = '{apartment.num}',name = '{apartment.name}',note =  '{apartment.note}' where id = '{apartment.id}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "部门编号重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }
        static public Apartment Query(string num, out string msg)
        {
            string command = $"select * from Apartment where num = '{num}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Apartment apartment = new Apartment((int)read["id"], (string)read["num"], (string)read["name"], (string)read["note"]);
            SQL.Dispose();
            msg = null;
            return apartment;
        }

        public static Dictionary<string, int> GetApartment()
        {
            string command = $"select id,num,name from Apartment";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {   
                SQL.Dispose();
                return null;
            }
            Dictionary<string,int> apartment = new Dictionary<string,int>();
            while (read.Read())
            {
                apartment.Add((string)read["name"]+"("+(string)read["num"]+")", (int)read["id"]);
            }
            SQL.Dispose();
            return apartment;
        }

        static public List<Apartment> QueryAll(out string msg)
        {
            string command = $"select * from Apartment";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<Apartment> list = new List<Apartment>();
            while (read.Read())
            {
                list.Add(new Apartment((int)read["id"], (string)read["num"], (string)read["name"], read["note"].ToString()));
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
    }
}