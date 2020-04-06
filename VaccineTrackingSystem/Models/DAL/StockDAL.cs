using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.DAL
{
    public class StockDAL
    {
        static public bool Add(Stock stock, string msg) {
            string command = $"insert into Stock (cagNum,storeID,quantity,money) values ('{stock.cagNum}','{stock.storeID}','{stock.quantity}','{stock.money})";
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

        static public Stock Query(int id, string msg) {
            string command = $"select * from Stock where id = '{id}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                return null;
            }
            Stock stock = new Stock((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (int)read["quantity"], (decimal)read["money"]);
            SQL.Dispose();
            return stock;
        }

        static public List<Stock> QueryAll(string msg) {
            string command = "select * from Stock";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                return null;
            }
            List<Stock> list = new List<Stock>();
            Stock stock;
            while (read.Read())
            {
                stock = new Stock((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (int)read["quantity"], (decimal)read["money"]);
                list.Add(stock);
            }
            SQL.Dispose();
            return list;
        }

        static public bool Update(Stock stock, string msg) {
            string command = $"update Stock set cagNum = '{stock.cagNum}',storeID = '{stock.storeID}',quantity = '{stock.quantity}',money = '{stock.money}'";
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

    }
}