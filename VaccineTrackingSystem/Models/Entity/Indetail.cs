﻿namespace VaccineTrackingSystem.Models
{
    public class Indetail
    {
        /* id */
        public int id;

        /* 库存id */
        public int stockID;

        /***到期时间***/
        public string batchNum;

        /****入库时间***/
        public string date;

        /* 数量 */
        public int quantity;

        /***单价***/
        public decimal price;


        /****备注***/
        public string note;

        /****批号***/
        public string batchNum2;

        public Indetail(int id, int stockID, string batchNum, string date, int quantity, decimal price, string note, string batchNum2)
        {
            this.id = id;
            this.stockID = stockID;
            this.batchNum = batchNum;
            this.date = date;
            this.quantity = quantity;
            this.price = price;
            this.note = note;
            this.batchNum2 = batchNum2;
        }

        public Indetail(int stockID, string batchNum, string date, int quantity, decimal price, string note, string batchNum2)
        {
            this.stockID = stockID;
            this.batchNum = batchNum;
            this.date = date;
            this.quantity = quantity;
            this.price = price;
            this.note = note;
            this.batchNum2 = batchNum2;
        }
        public Indetail() { }
    }
}