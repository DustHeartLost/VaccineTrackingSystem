using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models;

namespace VaccineTrackingSystem.Models.DAL
{
    public class ApartmentDAL
    {
		static public bool isExist(string table, string type, Apartment apartment)
		{
			string command = null;
			if (type == "id")
			{
				command = $"select id from {table} where id = '{apartment.id}'";
			}
			else if (type == "num")
			{
				command = $"select num from {table} where num = '{apartment.num}'";
			}
			else if (type == "name")
			{
				command = $"select name from {table} where name = '{apartment.name}'";
			}
			else if (type == "apartment")
			{
				command = $"select id from {table} where id = '{apartment.id}' and name = '{apartment.name}'";
			}
			try
			{
				if (SQL.getReader(command).HasRows)
				{
					SQL.Dispose();
					return true;
				}
				else
				{
					SQL.Dispose();
					return false;
				}
			}
			catch
			{
				return false;
			}
		}

		static public bool changePwd(string table, int  id, string newPassword)
		{
			string command = $"update {table} set password = '{newPassword}' where id = '{id}'";
			return SQL.Excute(command);
		}


	}
}