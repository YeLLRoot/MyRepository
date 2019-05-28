using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataBase
{
    class DBHelper:IDisposable
    {
         /// <summary>
        /// 受保护的数据库连接
        /// </summary>
        protected SqlConnection connection = null;
        /// <summary>
        /// 受保护的数据库连接字符串
        /// </summary>
        protected string connString = string.Empty;
        /// <summary>
        /// 构造函数，初始化数据库连接
        /// </summary>
        /// <param name="sqlConnection">数据库连接</param>
        public DBHelper(SqlConnection sqlConnection)
        {
            this.connection = sqlConnection;
            Open();
            this.connString = sqlConnection.ConnectionString;
        }
        /// <summary>
        /// 构造函数，初始化数据库连接字符串
        /// </summary>
        /// <param name="strConn">数据库连接字符串</param>
        public DBHelper(string strConn)
        {
            this.connString = strConn;
            Open();
        }
        /// <summary>
        /// 公共方法：打开数据库连接
        /// </summary>
        public void Open()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(connString);
                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 公共方法：关闭数据库连接
        /// </summary>
        public void Close()
        {
            if ((connection != null) && (connection.State != ConnectionState.Closed))
            {
                connection.Close();
            }
        }
        /// <summary>
        /// 公共方法：获取数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return connection;
        }
        /// <summary>
        /// 公共方法：获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public string GetConnString()
        {
            return connString;
        }
        /// <summary>
        /// 公共方法：释放非托管资源；实现IDisposable接口
        /// </summary>
        public void Dispose()
        {
            if (connection != null)
            {
                connection = null;
                GC.Collect();
            }
        }
    }
}
