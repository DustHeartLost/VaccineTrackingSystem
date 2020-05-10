using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.Models.DAL
{
    public class AlertDAL
    {
        static public bool Add(Alert alert, out string msg)
        {
            string command = $"insert into Alert(days,color) values('{alert.days}','{alert.color}');";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "剩余天数或颜色值重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }

        static public bool Update(Alert alert, out string msg)
        {
            string command = $"update Alert set days = '{alert.days}',color = '{alert.color}' where id = '{alert.id}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "剩余天数或颜色值重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }

        public static Dictionary<string, int> GetAlert()
        {
            string command = $"select color,days from Alert";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                SQL.Dispose();
                return null;
            }
            Dictionary<string, int> alert = new Dictionary<string, int>();
            while (read.Read())
            {
                alert.Add((string)read["color"] , (int)read["days"]);
            }
            SQL.Dispose();
            return alert;
        }

        static public List<Alert> QueryAll(out string msg)
        {
            string command = $"select * from Alert";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<Alert> list = new List<Alert>();
            while (read.Read())
            {
                list.Add(new Alert((int)read["id"], (int)read["days"], (string)read["color"]));
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

        static public bool Delete(int id, out string msg)
        {
            string command = $"delete from Alert where id ={id}";
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