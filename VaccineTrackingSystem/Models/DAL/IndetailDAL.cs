using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.DAL
{
    public class IndetailDAL
    {
        static public bool Add(Indetail indetail, string msg) {
            string command = $"insert into Indetail (num,name,kind,unit,spec,factory,note) values ('{indetail.num}','{indetail.name}','{indetail.kind}','{indetail.unit}','{indetail.spec}','{indetail.factory}','{indetail.note}')";
            try
            {
                return SQL.Excute(command);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }
        
        static public Indetail Query(int id, string msg) {
            string command = $"select * from Indetail where id = '{id}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                return null;
            }
            Indetail indetail = new Indetail((int)read["id"], (string)read["num"], (string)read["name"], (string)read["kind"], (string)read["unit"], (string)read["spec"], (string)read["factory"], (string)read["note"]);
            SQL.Dispose();
            return indetail;
        }
        
        static public List<Indetail> QueryAll(string msg) {
            string command = "select * from Indetail";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                return null;
            }
            List<Indetail> list = new List<Indetail>();
            Indetail indetail;
            while (read.Read())
            {
                indetail = new Indetail((int)read["id"], (string)read["num"], (string)read["name"], (string)read["kind"], (string)read["unit"], (string)read["spec"], (string)read["factory"], (string)read["note"]);
                list.Add(indetail);
            }
            SQL.Dispose();
            return list;
        }
        
        static public bool Update(Indetail indetail, string msg) {
            string command = $"update Indetail set num = '{indetail.num}',name = '{indetail.name}',kind = '{indetail.kind}',unit = '{indetail.unit}',spec = '{indetail.spec}',factory = '{indetail.factory}',note =  '{indetail.note}' where id = '{indetail.id}'";
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

        static public bool Delete(int id, string msg) {
            string command = $"delete from Indetail where id ={id}";
            try
            {
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