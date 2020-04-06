using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models
{
    public class Stock
    {
		/* 库存id */
		public int id;

		/*关联药品编码 */
		public string cagNum;

		/* 关联库房编号 */
		public int storeID;

		/* 数量 */
		public int quantity;

		/* 金额 */
		public decimal money;

		public Stock(int id, string cagNum, int storeID, int quantity, decimal money)
		{
			this.id = id;
			this.cagNum = cagNum;
			this.storeID = storeID;
			this.quantity = quantity;
			this.money = money;
		}
		public Stock(string cagNum, int storeID, int quantity, decimal money)
		{
			this.cagNum = cagNum;
			this.storeID = storeID;
			this.quantity = quantity;
			this.money = money;
		}
	}
}