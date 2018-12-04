using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace InductionDAL
{
    public class DatabaseHandler
    {
        private static string _connectionString = string.Empty;
        public static string ConnectionString
        {
            get
            {
                if (_connectionString==string.Empty)
                {
                  _connectionString = Convert.ToString(ConfigurationManager.AppSettings.Get("ConnectionString"));                    
                }
                return _connectionString;
            }
        }

        public SqlCommand GetCommand(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            return sqlCmd;
        }
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            return dt;
        }

        public DataTable Execute(SqlCommand command)
        {
            DataTable dt = new DataTable();
            command.Connection.Open();
            //command.ExecuteNonQuery();
            dt.Load(command.ExecuteReader());
            command.Connection.Close();
            return dt;
        }


        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = GetCommand(sql);
            cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
        public int ExecuteNonQuery(SqlCommand command)
        {
            command.Connection.Open();
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            return result;
        }

        public int ExecuteStoredProcedure(string spName)
        {
            SqlCommand cmd = GetCommand(spName);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
        public int ExecuteStoredProcedure(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            return result;
        }

    }
}
