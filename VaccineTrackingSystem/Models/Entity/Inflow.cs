using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models
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

        /****批号***/
        public string batchNum;

        public Inflow(int id, string cagNum, int storeID, string date, string userNum, int quantity, int price, string batchNum)
        {
            this.id = id;
            this.cagNum = cagNum;
            this.storeID = storeID;
            this.date = date;
            this.userNum = userNum;
            this.quantity = quantity;
            this.price = price;
            this.batchNum = batchNum;
        }
    }
}