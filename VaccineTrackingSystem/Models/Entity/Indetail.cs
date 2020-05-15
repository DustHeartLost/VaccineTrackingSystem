namespace VaccineTrackingSystem.Models
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

        /****供应商***/
        public string suppliers;
        
        /****批号***/
        public string batchNum2;

        /****备注***/
        public string note;
        public Indetail(int id, int stockID, string batchNum, string date, int quantity, decimal price,  string batchNum2,string suppliers,string note)
        {
            this.id = id;
            this.stockID = stockID;
            this.batchNum = batchNum;
            this.date = date;
            this.quantity = quantity;
            this.price = price;
            this.note = note;
            this.suppliers = suppliers;
            this.batchNum2 = batchNum2;
        }

        public Indetail(int stockID, string batchNum, string date, int quantity, decimal price, string batchNum2, string suppliers, string note)
        {
            this.stockID = stockID;
            this.batchNum = batchNum;
            this.date = date;
            this.quantity = quantity;
            this.price = price;
            this.note = note;
            this.batchNum2 = batchNum2;
            this.suppliers = suppliers;
        }
        public Indetail() { }
    }
}