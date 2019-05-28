using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace SqlHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection con = DBHelper.getConnection();

            con.Open();

            string sql = "select * from user";
            
            MySqlCommand cmd = new MySqlCommand(sql,con);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Console.Write(dt.Rows[i]["username"]);
                    Console.Write("   ");
                    Console.WriteLine(dt.Rows[i]["pwd"]);
                }
                
            }
            Console.ReadKey();
        }

    }
}
