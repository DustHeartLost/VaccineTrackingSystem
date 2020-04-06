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
		string password;

		/* 关联部门id */
		int apartID;

		/* 职务 */
		string job;

		/* 关联角色id */
		int roleID;

		/*员工编号*/
		string num;

		/*用户名*/
		string name;

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

	}
}
 