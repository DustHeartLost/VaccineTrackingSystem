using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VaccineTrackingSystem.Models.DAL
{
    public class StockDAL
    {
        static public bool Add(Stock stock, out string msg)
        {
            string command = $"insert into Stock (cagNum,storeID,quantity,money) values ('{stock.cagNum}','{stock.storeID}','{stock.quantity}','{stock.money}')";
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

        static public Stock QueryById(int id, out string msg)
        {
            string command = $"select * from Stock where id = '{id}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                return null;
            }
            Stock stock = new Stock((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (int)read["quantity"], (decimal)read["money"]);
            SQL.Dispose();
            msg = null;
            return stock;
        }

        //新增查询库存
        static public Stock QueryByCagNum(string cagNum, int storeID, out string msg)
        {
            string command = $"select * from Stock where cagNum = '{cagNum}' and storeID = '{storeID}' ";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "该库房暂无该药品";
                return null;
            }
            Stock stock = new Stock((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (int)read["quantity"], (decimal)read["money"]);
            SQL.Dispose();
            msg = null;
            return stock;
        }

        //新增 根库房id查询
        static public List<Stock> QueryByStoreId(int storeID, out string msg)
        {
            string command = $"select * from Stock where storeID = '{storeID}' ";
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
            msg = null;
            return list;
        }



        static public List<Stock> QueryAll(out string msg)
        {
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
            msg = null;
            return list;
        }

        static public bool Update(Stock stock, out string msg)
        {
            string command = $"update Stock set cagNum = '{stock.cagNum}',storeID = '{stock.storeID}',quantity = '{stock.quantity}',money = '{stock.money}' where id = '{stock.id}' ";
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
        static public Stock Query(string cagNum, int storeID, out string msg)
        {
            string command = $"select * from Stock where cagNum = '{cagNum}' and storeID =  '{storeID}'";
            SqlDataReader read = SQL.getData(command);
            if (read == null)
            {
                msg = "查询结果为空";
                return null;
            }
            Stock stock = new Stock((int)read["id"], (string)read["cagNum"], (int)read["storeID"], (int)read["quantity"], (decimal)read["money"]);
            SQL.Dispose();
            msg = null;
            return stock;
        }
        //新加的查询详细库存的接口
        static public List<Dictionary<string,string>> QueryAllStockDetail(out string msg)
        {
            string command = "select Category.num,Category.name,Category.unit,Category.spec,Category.factory,Stock.quantity,Stock.money,Stock.storeID,Stock.ID as stockID from Category, Stock where Category.num = Stock.cagNum";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            int i = 0;
            Dictionary<string, string> dictionary = new Dictionary<string,string>();
            while (read.Read())
            {
                dictionary.Add("id", (++i).ToString());
                dictionary.Add("num", (string)read["num"]);
                dictionary.Add("name", (string)read["name"]);
                dictionary.Add("unit", (string)read["unit"]);
                dictionary.Add("spec", (string)read["spec"]);
                dictionary.Add("factory", (string)read["factory"]);
                dictionary.Add("quantity", read["quantity"].ToString());
                dictionary.Add("money", read["money"].ToString());
                dictionary.Add("storeID", read["storeID"].ToString());
                dictionary.Add("stockID", read["stockID"].ToString());
                list.Add(dictionary);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

        static public List<Dictionary<string, string>> QueryStockDetail(string num, out string msg) {
            string command = $"select Category.num,Category.name,Category.unit,Category.spec,Category.factory,Stock.quantity,Stock.money,Stock.storeID,Stock.ID as stockID from Category, Stock where Category.num = Stock.cagNum and Category.num={num}";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "查询结果为空";
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            int i = 0;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            while (read.Read())
            {
                dictionary.Add("id", (++i).ToString());
                dictionary.Add("num", (string)read["num"]);
                dictionary.Add("name", (string)read["name"]);
                dictionary.Add("unit", (string)read["unit"]);
                dictionary.Add("spec", (string)read["spec"]);
                dictionary.Add("factory", (string)read["factory"]);
                dictionary.Add("quantity", read["quantity"].ToString());
                dictionary.Add("money", read["money"].ToString());
                dictionary.Add("storeID", read["storeID"].ToString());
                dictionary.Add("stockID", read["stockID"].ToString());
                list.Add(dictionary);
            }
            SQL.Dispose();
            msg = null;
            return list;

        }
    }
}