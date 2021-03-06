﻿namespace VaccineTrackingSystem.Models
{
    public class Inflow
    {
        /* id */
        public int id;

        /* 药品编码 */
        public string cagNum;

        /***关联库房编号***/
        public int storeID;

        /****入库时间***/
        public string date;

        /* 关联员工编号 */
        public string userNum;

        /***数量***/
        public int quantity;

        /****单价***/
        public decimal price;

        /****到期时间***/
        public string batchNum;

        /****批号***/
        public string batchNum2;

        /****供应商***/
        public string suppliers;

        /***备注***/
        public string notes;

        public Inflow(int id, string cagNum, int storeID, string date, string userNum, int quantity, decimal price, string batchNum, string batchNum2, string suppliers)
        {
            this.id = id;
            this.cagNum = cagNum;
            this.storeID = storeID;
            this.date = date;
            this.userNum = userNum;
            this.quantity = quantity;
            this.price = price;
            this.batchNum = batchNum;
            this.batchNum2 = batchNum2;
            this.suppliers = suppliers;
        }
        public Inflow(string cagNum, int storeID, string date, string userNum, int quantity, decimal price, string batchNum, string batchNum2, string suppliers)
        {
            this.cagNum = cagNum;
            this.storeID = storeID;
            this.date = date;
            this.userNum = userNum;
            this.quantity = quantity;
            this.price = price;
            this.batchNum = batchNum;
            this.batchNum2 = batchNum2;
            this.suppliers = suppliers;
        }
        public Inflow(string cagNum, int storeID, string date, string userNum, int quantity, decimal price, string batchNum, string batchNum2, string suppliers, string notes)
        {
            this.cagNum = cagNum;
            this.storeID = storeID;
            this.date = date;
            this.userNum = userNum;
            this.quantity = quantity;
            this.price = price;
            this.batchNum = batchNum;
            this.batchNum2 = batchNum2;
            this.suppliers = suppliers;
            this.notes = notes;
        }
    }
}