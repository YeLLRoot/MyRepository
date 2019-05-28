using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace SqlHelper
{
    public class DBHelper
    {

        //获取连接
        public static MySqlConnection getConnection()
        {
            string conStr = "server=127.0.0.1;port=3306;user=root;password=123456;database=zt";
            MySqlConnection con = new MySqlConnection(conStr);
            return con;
        }

    }
}
