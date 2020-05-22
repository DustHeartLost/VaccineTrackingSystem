using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SQL
    {
        #region 定义数据库成员
        private static string ConnectionStringSQL = ConfigurationManager.ConnectionStrings["VaccineTrackingSystem"].ConnectionString;
        static public SqlCommand Com;
        static public SqlConnection Con;
        static public SqlDataReader Read;
        static public SqlDataAdapter Ada;
        static public SqlCommandBuilder CB;
        static public DataSet Set;
        #endregion

        #region 释放数据库对象
        static public void Dispose()
        {
            Con.Close();
            Com.Dispose();
            Con.Dispose();
        }
        #endregion

        static public bool Excute(string Command)
        {
            Con = new SqlConnection(ConnectionStringSQL);
            Con.Open();
            if (Con.State == ConnectionState.Open)
            {
                Com = new SqlCommand(Command, Con);
            }
            try
            {
                if (Com.ExecuteNonQuery() > 0)
                {
                    Dispose();
                    return true;
                }
                else
                {
                    Dispose();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Number);
                Dispose();
                //这里修改一下，改为抛出异常，合并冲突的时候不要合并
                throw ex;
            }
        }
        static public SqlDataReader getData(string Command)
        {
            Con = new SqlConnection(ConnectionStringSQL);
            Con.Open();
            if (Con.State == ConnectionState.Open)
            {
                Com = new SqlCommand(Command, Con);
            }
            Read = SQL.Com.ExecuteReader();
            if (Read.HasRows)
            {
                Read.Read();
                return Read;
            }
            return null;
        }

        static public SqlDataReader getReader(string Command)
        {
            Con = new SqlConnection(ConnectionStringSQL);
            Con.Open();
            if (Con.State == ConnectionState.Open)
            {
                Com = new SqlCommand(Command, Con);
            }
            return SQL.Com.ExecuteReader();
        }

        /// <summary>
        /// 执行语句
        /// </summary>
        static public bool ExecuteTransaction(List<string> list, out string msg)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringSQL))
            {
                SqlCommand command = new SqlCommand();
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    for (int i = 0; i < list.Count; i++)
                    {
                        command.CommandText = list[i];
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    connection.Close();
                    msg = "";
                    return true;
                }
                catch (SqlException e)
                {
                    msg = "";
                    if (e.Number == 2627)
                        msg = "批号重复，插入失败";
                    else
                        msg = e.Message;
                    transaction.Rollback();
                    connection.Close();
                    return false;
                }
            }
        }
    }
}