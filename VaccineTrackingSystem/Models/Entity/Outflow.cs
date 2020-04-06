using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models
{
    public class Outflow
    {
        /* id */
        public int id;

        /* 药品编码 */
        public string cagNum;

        /***库房编号***/
        public int storeID;

        /****入库时间***/
        public string date;

        /* 员工编号 */
        public string userNum;

        /***数量***/
        public int quantity;

        /****单价***/
        public decimal price;

        /****批号***/
        public string batchNum;

        /*状态*/
        public string state;

        public Outflow(int id, string cagNum, int storeID, string date, string userNum, int quantity, decimal price, string batchNum, string state)
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
        }
    }
}