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
            string command = $"insert into Indetail (stockID,batchNum,date,quantity,price,batchNum2,suppliers,note) values ('{indetail.stockID}','{indetail.batchNum}','{indetail.date}','{indetail.quantity}','{indetail.price}','{indetail.batchNum2}','{indetail.suppliers}','{indetail.note}')";
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

        static public Indetail QueryById(int id, out string msg)
        {
            string command = $"select * from Indetail where id = '{id}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            Indetail indetail = new Indetail((int)read["id"], (int)read["stockID"], (string)read["batchNum"], (string)read["date"], (int)read["quantity"], (decimal)read["price"], read["batchNum2"].ToString(), read["suppliers"].ToString(), read["note"].ToString());
            SQL.Dispose();
            msg = null;
            return indetail;
        }
        //static public Indetail Query(int stockID, string batchNum, string date, decimal price,string batchNum2,string suppliers, out String msg)
        //{
        //    string command = $"select * from Indetail where stockID = '{stockID}' and batchNum = '{batchNum}' and date = '{date}' and price = '{price}' and batchNum2='{batchNum2}' and suppliers='{suppliers}'";
        //    SqlDataReader read = SQL.getData(command);
        //    if (read == null)
        //    {
        //        msg = "查询结果为空";
        //        SQL.Dispose();
        //        return null;
        //    }
        //    Indetail indetail = new Indetail((int)read["id"], (int)read["stockID"], (string)read["batchNum"], (string)read["date"], (int)read["quantity"], (decimal)read["price"], read["batchNum2"].ToString(),read["suppliers"].ToString(), read["note"].ToString());
        //    SQL.Dispose();
        //    msg = null;
        //    return indetail;
        //}
        static public List<Dictionary<string,string>> QueryByStockID(int stockID, out string msg)
        {
            string command = $"with temp as(select Stock.cagNum,Indetail.id,stockID,batchNum,date,Indetail.quantity,price,Indetail.batchNum2,Indetail.suppliers,Indetail.note from Indetail,Stock where stockID = '{stockID}' and Indetail.stockID=Stock.id) "+
                             "select temp.cagNum,Category.name,Category.kind,Category.spec,temp.id,temp.stockID,temp.batchNum,temp.date,temp.quantity,temp.price,temp.batchNum2,temp.suppliers,temp.note " +
                             "from temp,Category "+
                             "where Category.num = cagNum;";
            SqlDataReader read;
            read = SQL.getReader(command); 
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("stockID", read["stockID"].ToString());
                d.Add("cagNum", (string)read["cagNum"]);
                d.Add("name", (string)read["name"]);
                d.Add("kind", (string)read["kind"]);
                d.Add("spec", (string)read["spec"]);
                d.Add("batchNum", (string)read["batchNum"]);
                d.Add("date", (string)read["date"]);
                d.Add("quantity", read["quantity"].ToString());
                d.Add("price", read["price"].ToString());
                d.Add("batchNum2", read["batchNum2"].ToString());
                d.Add("suppliers", read["suppliers"].ToString());
                d.Add("note",read["note"].ToString());
                list.Add(d);
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