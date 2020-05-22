using DAL;
using Newtonsoft.Json.Linq;
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
                SQL.Dispose();
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
                SQL.Dispose();
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
                SQL.Dispose();
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
                return false;
            }
        }

        static public List<Dictionary<string, string>> QueryStockDetail(int storeID, string num, out string msg)
        {
            string command = "";
            if (storeID == -1 && num != null)
                command = $"select Category.num,Category.name,Category.kind,Category.unit,Category.spec,Stock.quantity,Stock.money,Storeroom.name as storeID,Stock.ID as stockID from Category, Stock,Storeroom where Category.num = Stock.cagNum and Storeroom.id=Stock.storeID and Category.num='{num}';";
            else if (storeID != -1 && num != null)
                command = $"select Category.num,Category.name,Category.kind,Category.unit,Category.spec,Stock.quantity,Stock.money,Storeroom.name as storeID,Stock.ID as stockID from Category, Stock,Storeroom where Category.num = Stock.cagNum and Storeroom.id=Stock.storeID and Category.num='{num}' and Stock.storeID={storeID};";
            else if (storeID == -1 && num == null)
                command = $"select Category.num,Category.name,Category.kind,Category.unit,Category.spec,Stock.quantity,Stock.money,Storeroom.name as storeID,Stock.ID as stockID from Category, Stock,Storeroom where Category.num = Stock.cagNum and Storeroom.id=Stock.storeID;";
            else if (storeID != -1 && num == null)
                command = $"select Category.num,Category.name,Category.kind,Category.unit,Category.spec,Stock.quantity,Stock.money,Storeroom.name as storeID,Stock.ID as stockID from Category, Stock,Storeroom where Category.num = Stock.cagNum and Storeroom.id=Stock.storeID and Stock.storeID={storeID};";
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
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("num", (string)read["num"]);
                dictionary.Add("name", (string)read["name"]);
                dictionary.Add("kind", (string)read["kind"]);
                dictionary.Add("unit", (string)read["unit"]);
                dictionary.Add("spec", (string)read["spec"]);
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

        //根据药品编号查询库存
        static public List<Dictionary<string, string>> QueryCagNum(string cagNum, int storeID, out string msg)
        {
            string command;
            command = $"select Stock.id,Stock.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Stock.quantity,Stock.money from Stock,Storeroom,Category where Stock.storeID = Storeroom.id and Stock.cagNum = Category.num and Storeroom.id = {storeID} and Stock.cagNum = '{cagNum}'";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "未查询到库存记录";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("cagNum", (string)read["cagNum"]);
                d.Add("name", (string)read["name"]);
                d.Add("kind", (string)read["kind"]);
                d.Add("spec", (string)read["spec"]);
                d.Add("storeID", (string)read["storeID"]);
                d.Add("quantity", read["quantity"].ToString());
                d.Add("money", read["money"].ToString());
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

        //根据库房id查询库存记录
        static public List<Dictionary<string, string>> QueryAllByStoreID(int storeID, out string msg)
        {
            string command;
            command = $"select Stock.id,Stock.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Stock.quantity,Stock.money from Stock,Storeroom,Category where Stock.storeID = Storeroom.id and Stock.cagNum = Category.num and Storeroom.id = {storeID}";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "库存列表为空";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("cagNum", (string)read["cagNum"]);
                d.Add("name", (string)read["name"]);
                d.Add("kind", (string)read["kind"]);
                d.Add("spec", (string)read["spec"]);
                d.Add("storeID", (string)read["storeID"]);
                d.Add("quantity", read["quantity"].ToString());
                d.Add("money", read["money"].ToString());
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }

        static public List<Dictionary<string, string>> CombinationQuery(JObject keyWords, int storeID, out string msg)
        {
            string command = "";
            if (storeID == -1)
                command = $"select Category.num,Category.name,Category.kind,Category.unit,Category.spec,Stock.quantity,Stock.money,Storeroom.name as storeID,Stock.ID as stockID from Category, Stock,Storeroom where Category.num = Stock.cagNum and Storeroom.id=Stock.storeID  and Category.num like '{keyWords["cagNum"]}' and Category.name like '{keyWords["cagName"]}' and Storeroom.name like '{keyWords["storeName"]}' and Category.kind like '{keyWords["drug"]}';";
            else
                command = $"select Category.num,Category.name,Category.kind,Category.unit,Category.spec,Stock.quantity,Stock.money,Storeroom.name as storeID,Stock.ID as stockID from Category, Stock,Storeroom where Category.num = Stock.cagNum and Storeroom.id=Stock.storeID  and Stock.storeID={storeID} and Category.num like '{keyWords["cagNum"]}' and Category.name like '{keyWords["cagName"]}'  and Storeroom.name like '{keyWords["storeName"]}' and Category.kind like '{keyWords["drug"]}'";
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
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("num", (string)read["num"]);
                dictionary.Add("name", (string)read["name"]);
                dictionary.Add("kind", (string)read["kind"]);
                dictionary.Add("unit", (string)read["unit"]);
                dictionary.Add("spec", (string)read["spec"]);
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

        //根据药品名称查询库存
        static public List<Dictionary<string, string>> QueryCagName(string cagName, int storeID, out string msg)
        {
            string command;
            command = $"select Stock.id,Stock.cagNum,Category.name,Category.kind,Category.spec,Storeroom.name as storeID,Stock.quantity,Stock.money from Stock,Storeroom,Category where Stock.storeID = Storeroom.id and Stock.cagNum = Category.num and Storeroom.id = {storeID} and Category.name like '{cagName}'";
            SqlDataReader read;
            read = SQL.getReader(command);
            if (!read.HasRows)
            {
                msg = "未查询到库存记录";
                SQL.Dispose();
                return null;
            }
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            while (read.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("id", read["id"].ToString());
                d.Add("cagNum", (string)read["cagNum"]);
                d.Add("name", (string)read["name"]);
                d.Add("kind", (string)read["kind"]);
                d.Add("spec", (string)read["spec"]);
                d.Add("storeID", (string)read["storeID"]);
                d.Add("quantity", read["quantity"].ToString());
                d.Add("money", read["money"].ToString());
                list.Add(d);
            }
            SQL.Dispose();
            msg = null;
            return list;
        }
    }
}