using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class IndetailDAL
    {
        static public bool Add(Indetail indetail, out string msg)
        {
            string command = $"insert into Indetail (stockID,batchNum,date,quantity,price,note) values ('{indetail.stockID}','{indetail.batchNum}','{indetail.date}','{indetail.quantity}','{indetail.price}','{indetail.note}')";
            try
            {
                msg = null;
                return SQL.Excute(command);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

        static public Indetail Query(int id, out string msg)
        {
            string command = $"select * from Indetail where id = '{id}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                return null;
            }
            Indetail indetail = new Indetail((int)read["id"], (int)read["stockID"], (string)read["batchNum"], (string)read["date"], (int)read["quantity"], (decimal)read["price"], read["note"].ToString());
            SQL.Dispose();
            msg = null;
            return indetail;
        }

        static public List<Indetail> QueryAll(out string msg)
        {
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
                indetail = new Indetail((int)read["id"], (int)read["stockID"], (string)read["batchNum"], (string)read["date"], (int)read["quantity"], (decimal)read["price"], read["note"].ToString());
                list.Add(indetail);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

        static public bool Update(Indetail indetail, out string msg)
        {
            string command = $"update Indetail set stockID = '{indetail.stockID}',batchNum = '{indetail.batchNum}',date = '{indetail.date}',quantity = '{indetail.quantity}',price = '{indetail.price}',note = '{indetail.note}'  where id = '{indetail.id}'";
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
            string command = $"delete from Indetail where id ={id}";
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