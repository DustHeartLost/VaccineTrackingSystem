using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using VaccineTrackingSystem.Models;

namespace VaccineTrackingSystem.Models.DAL
{
	public class ApartmentDAL
	{

		static public bool Add(Apartment apartment, string msg)
		{
			string command = $"insert into Apartment(num,name,note) values('{apartment.num}','{apartment.name}','{apartment.note}');";
			try
			{
				return SQL.Excute(command);
			}
			catch (Exception e)
			{
				msg = e.Message;
				System.Diagnostics.Debug.Write(msg);
				return false;
			}
		}
		static public bool Delete(int id, string msg)
		{
			string command = $"delete from Apartment where id ={id}";
			try
			{
				return SQL.Excute(command);
			}
			catch (Exception e)
			{
				msg = e.Message;
				System.Diagnostics.Debug.Write(msg);
				return false;
			}
		}
		static public bool Update(Apartment apartment, string msg)
		{
			string command = $"update Apartment set num = '{apartment.num}',name = '{apartment.name}',note =  '{apartment.note}' where id = '{apartment.id}'";
			try
			{
				return SQL.Excute(command);
			}
			catch (Exception e)
			{
				msg = e.Message;
				System.Diagnostics.Debug.Write(msg);
				return false;
			}
		}
		static public Apartment Query(string num, string msg)
		{
			string command = $"select * from Apartment where num = '{num}'";
			SqlDataReader read = SQL.getData(command);
			if (read == null)
			{
				msg = "查询结果为空";
				SQL.Dispose();
				return null;
			}
			Apartment apartment = new Apartment((int)read["id"], (string)read["num"], (string)read["name"], (string)read["note"]);
			SQL.Dispose();
			return apartment;
		}

		static public List<Apartment> QueryAll(string msg)
		{
			string command = $"select * from Apartment";
			SqlDataReader read = SQL.getReader(command);
			if (read == null)
			{
				msg = "当前暂无记录";
				SQL.Dispose();
				return null;
			}
			List<Apartment> list = new List<Apartment>();
			while (read.Read())
			{
				list.Add(new Apartment((int)read["id"],(string)read["num"], (string)read["name"],(string)read["note"]));
			}
			SQL.Dispose();
			return list;
		}
	}
}