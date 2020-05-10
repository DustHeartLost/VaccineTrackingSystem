using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.Models.DAL
{
    public class DrugDAL
    {
        static public bool Add(Drug drug,out string msg)
        {
            string command = $"insert into Drug(kind) values('{drug.kind}');";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "药品品类重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }

        static public bool Update(Drug drug, out string msg)
        {
            string command = $"update Drug set kind = '{drug.kind}'  where id = '{drug.id}'";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    msg = "药品品类重复";
                }
                else
                {
                    msg = e.Message;
                }
                return false;
            }
        }

        static public Drug Query(string kind, out string msg)
        {
            string command = $"select * from Drug where kind = '{kind}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Drug drug = new Drug((int)read["id"], (string)read["kind"]);
            SQL.Dispose();
            msg = null;
            return drug;
        }

        static public List<Drug> QueryAll(out string msg)
        {
            string command = "select * from Drug";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                msg = "当前暂无记录";
                SQL.Dispose();
                return null;
            }
            List<Drug> list = new List<Drug>();
            while (read.Read())
            {
                list.Add(new Drug((int)read["id"], (string)read["kind"]));
            }
            SQL.Dispose();
            msg = null;
            return list;
        }


        static public bool Delete(int id, out string msg)
        {
            string command = $"delete from Drug where id ={id}";
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

        static public Dictionary<string, int> GetDrug()
        {
            string command = $"select id,kind from Drug;";
            SqlDataReader read = SQL.getReader(command);
            if (read == null)
            {
                SQL.Dispose();
                return null;
            }
            Dictionary<string, int> drug = new Dictionary<string, int>();
            while (read.Read())
            {
                drug.Add((string)read["kind"], (int)read["id"]);
            }
            SQL.Dispose();
            return drug;
        }
    }
}