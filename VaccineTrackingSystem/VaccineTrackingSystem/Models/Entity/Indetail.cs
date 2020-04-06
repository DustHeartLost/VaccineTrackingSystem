using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models
{
    public class Indetail
    {
        /* id */
        public int id;

        /* 库存id */
        public string stockID;

        /***批号***/
        public string batchNum;

        /****入库时间***/
        public string date;

        /* 数量 */
        public string quantity;

        /***单价***/
        public string price;


        /****备注***/
        public string note;

        public Indetail(int id, string stockID, string batchNum, string date, string quantity, string price, string note)
        {
            this.id = id;
            this.stockID = stockID;
            this.batchNum = batchNum;
            this.date = date;
            this.quantity = quantity;
            this.price = price;
            this.note = note;
        }

        public Indetail(string stockID, string batchNum, string date, string quantity, string price, string note)
        {
            this.stockID = stockID;
            this.batchNum = batchNum;
            this.date = date;
            this.quantity = quantity;
            this.price = price;
            this.note = note;
        }
    }
}