﻿namespace VaccineTrackingSystem.Models
{
    public class Outflow
    {
        /* id */
        public int id;

        /* 药品编码 */
        public string cagNum;

        /***库房编号***/
        public int storeID;

        /****出库时间***/
        public string date;

        /* 员工编号 */
        public string userNum;

        /***数量***/
        public int quantity;

        /****单价***/
        public decimal price;

        /****到期时间***/
        public string batchNum;

        /*状态*/
        public string state;

        /****批号***/
        public string batchNum2;

        /*供应商*/
        public string suppliers;

        public Outflow(int id, string cagNum, int storeID, string date, string userNum, int quantity, decimal price, string batchNum, string batchNum2, string suppliers, string state)
        {
            this.id = id;
            this.cagNum = cagNum;
            this.storeID = storeID;
            this.date = date;
            this.userNum = userNum;
            this.quantity = quantity;
            this.price = price;
            this.batchNum = batchNum;
            this.state = state;
            this.batchNum2 = batchNum2;
            this.suppliers = suppliers;
        }
        public Outflow(string cagNum, int storeID, string date, string userNum, int quantity, decimal price, string batchNum, string batchNum2, string suppliers, string state)
        {
            this.cagNum = cagNum;
            this.storeID = storeID;
            this.date = date;
            this.userNum = userNum;
            this.quantity = quantity;
            this.price = price;
            this.batchNum = batchNum;
            this.state = state;
            this.batchNum2 = batchNum2;
            this.suppliers = suppliers;
        }
    }
}