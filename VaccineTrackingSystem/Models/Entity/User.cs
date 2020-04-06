using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models
{
    public class User
    {

		/* id */
		public int id;

		/* 用户名称 */
		public string userName;

		/* 密码 */
		public string password;

		/* 关联部门id */
		public int apartID;

		/* 职务 */
		public string job;

		/* 关联角色id */
		public int roleID;

		/*员工编号*/
		public string num;

		/*用户名*/
		public string name;

		public User(int id, string userName, string password, int apartID, string job, int roleID, string num, string name)
		{
			this.id = id;
			this.userName = userName;
			this.password = password;
			this.apartID = apartID;
			this.job = job;
			this.roleID = roleID;
			this.num = num;
			this.name = name;
		}
		public User(string userName, string password, int apartID, string job, int roleID, string num, string name)
		{
			this.userName = userName;
			this.password = password;
			this.apartID = apartID;
			this.job = job;
			this.roleID = roleID;
			this.num = num;
			this.name = name;
		}

	}
}
 